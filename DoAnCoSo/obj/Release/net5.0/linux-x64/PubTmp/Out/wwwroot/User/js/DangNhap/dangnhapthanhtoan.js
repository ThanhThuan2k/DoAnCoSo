const loginForm = select('#customer_login');
loginForm.addEventListener('submit', async function (e) {
	e.preventDefault();
	console.log("submit");
	let email = select('#customer_email').value;
	let password = select('#customer_password').value;

	if (email == "") {
		select('#customer_email').focus();
		select('#customer_email').classList.add('error');
	} else if (password == "") {
		select('#customer_password').focus();
		select('#customer_password').classList.add('error');
	} else {
		await axios.post('/dathang/dangnhap', { email: email, password: password }).then(function (response) {
			console.log(response);
			if (response.data == true) {
				window.location.href = "/dathang";
			} else {
				Swal.fire({
					icon: 'error',
					title: 'Oops...',
					text: 'Email hoặc mật khẩu sai!'
				})
			}
		});
	}
});