const imageUploadContainer = select(".image-upload-container");
const imageUploadButton = select(".image-upload-button");
imageUploadContainer.addEventListener('click', () => {
	imageUploadButton.click();
});

imageUploadButton.addEventListener('change', () => {
	if (imageUploadButton.files && imageUploadButton.files[0]) {
		var reader = new FileReader();
		reader.onload = function (e) {
			let imageTag = create('img', 'image-upload-result');
			imageUploadContainer.textContent = "";
			imageTag.src = e.target.result;
			imageUploadContainer.insertAdjacentElement('beforeend', imageTag);
			imageUploadContainer.style.border = 'none';
		}
		reader.readAsDataURL(imageUploadButton.files[0]);
	}
});

select(".submit-button").addEventListener('click', () => {
	select(".them-moi-form").submit();
});