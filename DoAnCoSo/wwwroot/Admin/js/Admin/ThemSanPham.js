$(document).ready(function () {
	$('#summernote').summernote({
		placeholder: 'Mô tả chi tiết sản phẩm',
		height: 400,
		tabsize: 4
	});
});

function numberWithCommas(x) {
	return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}

const inputTag = document.querySelector("#GiaGocSanPham");
document.querySelector(".bootstrap-touchspin-down").addEventListener('click', function () {
	inputTag.value = numberWithCommas(parseInt(inputTag.value.replaceAll(',', '')) - 100000);
});
document.querySelector(".bootstrap-touchspin-up").addEventListener('click', function () {
	inputTag.value = numberWithCommas(parseInt(inputTag.value.replaceAll(',', '')) + 100000);
});