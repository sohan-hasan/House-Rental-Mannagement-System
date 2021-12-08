$(function () {
    $('.imageChange').change(function () {
        var input = this;
        if (input.files) {
            var rdr = new FileReader();
            rdr.onload = function (e) {
                $('.changeEdit').attr('src', e.target.result);
            }
            rdr.readAsDataURL(input.files[0]);
        }
    })
});
