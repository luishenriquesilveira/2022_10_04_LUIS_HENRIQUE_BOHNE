class Animal {
    searchZoo() {
        var category = document.getElementById('DdlCategory_id');
        
        $.ajax({
            url: '/animal/GetAll',
            type: 'GET',
            contentType: 'application/json',
            data: { categoryId: category.value },
            success: function (data) {
                var result = data;
                $('#SearchZooPartial').html(result);
            }
        });
    }
}

var animal = new Animal();