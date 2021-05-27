const LienHeForm = select('#contact');
LienHeForm.addEventListener('submit', function (e) {
	e.preventDefault();
	let data = {
		hoTen: select('#name').value,
		email: select('#email').value,
		soDienThoai: select('#tel').value,
		binhLuan: select('#comment').value
	}
	axios.post("/lienhepost", data).then(function (response) {
		if (response.data) {
			Swal.fire('Cảm ơn bạn đã liên hệ, chúng tôi sẽ phản hồi nhanh nhất có thể')
				.then(() => window.location.href = '/');
		} else {
			Swal.fire({
				icon: 'error',
				title: 'Oops...',
				text: 'Cảm ơn sự đóng góp ý kiến của bạn nhưng hiện tại chúng tôi đang gặp một số vấn đề kỹ thuật, vui lòng thử lại sau ít phút'
			})
		}
	})
});