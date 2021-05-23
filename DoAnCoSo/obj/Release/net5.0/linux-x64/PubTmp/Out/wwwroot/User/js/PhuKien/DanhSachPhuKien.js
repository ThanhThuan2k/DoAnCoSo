window.addEventListener('load', function (e) {
	callData();
});

const callData = () => {
	axios.get("/phukien/tatcaphukien").then(function (response) {
		console.log(response.data);
	});
}