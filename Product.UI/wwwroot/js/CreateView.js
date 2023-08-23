
(function () {
    $.ajax({
        url: "http://localhost:19209/api/categories/getall",
        type: 'GET',
        dataType: 'json',
        success: function (response) {
            const select = document.getElementById("CategoryId");
            for (var i = 0; i < response.length; i++) {
                const option = document.createElement("option");
                option.setAttribute("value", response[i].categoryId);
                option.innerHTML = response[i].name;
                select.append(option);
            }
        }
    });

})();

