    $(document).ready(function () {
        // Handle delete button click event
        $("#grid").on("click", ".k-grid-delete", function (e) {
            e.preventDefault();
            handleDeleteCustomer();
        });
        });

    function ConfigureDataSource(dataSource) {
        dataSource
            .Ajax()
            .PageSize(10)
            .Read(read => read.Action("Customers_Read", "Customer"))
            .Create(create => create.Action("Create", "Customer"))
            .Update(update => update.Action("Edit", "Customer"))
            .Destroy(destroy => destroy.Action("Delete", "Customer"))
            .Model(model => {
                model.Id(c => c.CustomerID);
                model.Field(c => c.CustomerID).Editable(false);
            });
        }


function handleDeleteCustomer() {
    var grid = $("#grid").data("kendoGrid");
    var dataItem = grid.dataItem($(this).closest("tr"));
    var customerId = dataItem.CustomerID;

    if (confirm("Are you sure you want to delete this customer?")) {
        $.ajax({
            url: "/Customer/Delete",
            type: "POST",
            data: { CustomerID: customerId },
            success: function (result) {
                if (result.success) {
                    // Reload the grid data source
                    grid.dataSource.read();
                    showAlert("Customer deleted successfully!");
                } else {
                    showAlert("Failed to delete customer. Please try again.");
                }
            },
            error: function () {
                alert("An error occurred while deleting the customer.");
            }
        });
    }
}

    function handleDeleteSuccess(result, grid) {
            if (result.success) {
        grid.dataSource.read();
    showAlert("Customer deleted successfully!");
            } else {
        showAlert("Failed to delete customer. Please try again.");
            }
        }

    function showAlert(message) {
            // Display success or failure alert
            var alertContainer = $("#alert-container");
    alertContainer.empty();
    alertContainer.append('<div class="alert alert-info">' + message + '</div>');
        }

  