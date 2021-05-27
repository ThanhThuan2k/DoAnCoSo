const sendData = async (data) => {
	let url = "/admin/login/index";
	await axios.post(url, data).then(res => {
		if (res.data !== true) {
			Swal.fire({
				icon: 'error',
				title: 'Oops...',
				text: 'Không tìm thấy tài khoản!'
			}).then(() => {
				document.querySelector("#username-input").value = "";
				document.querySelector("#password-input").value = "";
			});
		} else {
			window.location.href = "/admin";
		}
	});
}

document.querySelector(".btn-block").addEventListener('click', function (e) {
	let username = document.querySelector("#username-input").value;
	let password = document.querySelector("#password-input").value;
	let supperadmin = document.querySelector("#supperadmin");
	let rememberTag = document.querySelector("#remember");
	let isSupper = supperadmin.checked ? true : false;
	let remember = rememberTag.checked ? true : false;
	var data = {
		username: username,
		password: password,
		isSupper: isSupper,
		RememberMe: remember
	}
	console.log(data);
	sendData(data);
});