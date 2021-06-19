function ShowImagePreview(imageUploader, previewImage) {
    // lấy file nào đó
    if (imageUploader.files && imageUploader.files[0]) {
        // đọc file
        var reader = new FileReader();
        reader.onload = function (e) {
            // đưa hình vào thuộc tính đường dẫn
            $(previewImage).attr('src', e.target.result);
        }
        reader.readAsDataURL(imageUploader.files[0]);
    }
}