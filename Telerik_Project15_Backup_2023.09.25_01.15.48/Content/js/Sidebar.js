<script>
    $(document).ready(function () {
        $("#toggle-button").click(function () {
            $("#sidebar").toggleClass("active");
            if ($("#sidebar").hasClass("active")) {
                $(this).html("&#9668;"); // Change arrow to left-pointing
            } else {
                $(this).html("&#9658;"); // Change arrow to right-pointing
            }
        });
    });
</script>