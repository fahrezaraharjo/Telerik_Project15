$(document).ready(function () {
    // Create a Kendo Grid
    var grid = $("#customerGrid").kendoGrid({
        dataSource: {
            // Use the Razor Page URL route here
            transport: {
                read: {
                    url: "/Customer/Index", // Specify the Razor Page URL route
                    type: "POST"
                },
                destroy: {
                    // Use the Razor Page URL route with the id parameter here
                    url: function (dataItem) {
                        return "/Customer/OnPostDestroy/" + dataItem.CustomerID;
                    },
                    type: "POST"
                }
            },
            schema: {
                model: {
                    id: "CustomerID"
                }
            }
        },
        // Define your grid columns, toolbars, and other configurations here
        columns: [
            // ...
            {
                command: [
                    {
                        name: "edit",
                        text: "Edit"
                    },
                    {
                        name: "destroy",
                        text: "Delete"
                    }
                ],
                title: "&nbsp;",
                width: "200px"
            }
        ],
        editable: "popup" // Assuming you are using popup editing
    }).data("kendoGrid");

    // Handle the grid's delete button click event
    grid.bind("remove", function (e) {
        if (confirm("Are you sure you want to delete this record?")) {
            // Extract the CustomerID from the data item being deleted
            var customerId = e.model.CustomerID;

            // Send an AJAX request with the customerId
            $.ajax({
                url: e.model.destroy, // Use the destroy URL defined in the dataSource
                type: "POST",
                data: { id: customerId }, // Pass the customerId as the 'id' parameter
                success: function (data) {
                    // Handle the response as needed, such as refreshing the grid
                    grid.dataSource.read();
                },
                error: function (xhr, status, error) {
                    // Handle errors if necessary
                    console.error(error);
                }
            });
        } else {
            // Prevent the default delete action if the user cancels
            e.preventDefault();
        }
    });
});