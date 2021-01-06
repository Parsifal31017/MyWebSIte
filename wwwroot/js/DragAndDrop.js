let dropArea = document.getElementById('drop-area');['dragenter', 'dragover', 'dragleave', 'drop'].forEach(eventName => {
    dropArea.addEventListener(eventName, preventDefaults, false)
})
function preventDefaults(e) {
    e.preventDefault()
    e.stopPropagation()
};['dragenter', 'dragover'].forEach(eventName => {
    dropArea.addEventListener(eventName, highlight, false)
})
    ;['dragleave', 'drop'].forEach(eventName => {
        dropArea.addEventListener(eventName, unhighlight, false)
    })
function highlight(e) {
    dropArea.classList.add('highlight')
}
function unhighlight(e) {
    dropArea.classList.remove('highlight')
}
dropArea.addEventListener('drop', handleDrop, false)
function handleDrop(e) {
    let dt = e.dataTransfer
    let files = dt.files
    handleFiles(files)
}
function handleFiles(files) {
    ([...files]).forEach(uploadFile)
}
function uploadFile(file) {
    let url = 'ВАШ URL ДЛЯ ЗАГРУЗКИ ФАЙЛОВ'
    let formData = new FormData()
    formData.append('file', file)
    fetch(url, {
        method: 'POST',
        body: formData
    })
        .then(() => { /* Готово. Информируем пользователя */ })
        .catch(() => { /* Ошибка. Информируем пользователя */ })
}
function uploadFile(file) {
    var url = 'ВАШ URL ДЛЯ ЗАГРУЗКИ ФАЙЛОВ'
    var xhr = new XMLHttpRequest()
    var formData = new FormData()
    xhr.open('POST', url, true)
    xhr.addEventListener('readystatechange', function (e) {
        if (xhr.readyState == 4 && xhr.status == 200) {
            // Готово. Информируем пользователя
        }
        else if (xhr.readyState == 4 && xhr.status != 200) {
            // Ошибка. Информируем пользователя
        }
    })
    formData.append('file', file)
    xhr.send(formData)
}
function previewFile(file) {
    let reader = new FileReader()
    reader.readAsDataURL(file)
    reader.onloadend = function () {
        let img = document.createElement('img')
        img.src = reader.result
        document.getElementById('gallery').appendChild(img)
    }
}
function handleFiles(files) {
    files = [...files]
    files.forEach(uploadFile)
    files.forEach(previewFile)
}
let filesDone = 0
let filesToDo = 0
let progressBar = document.getElementById('progress-bar')
function initializeProgress(numfiles) {
    progressBar.value = 0
    filesDone = 0
    filesToDo = numfiles
}
function progressDone() {
    filesDone++
    progressBar.value = filesDone / filesToDo * 100
}
function handleFiles(files) {
    files = [...files]
    initializeProgress(files.length) // <- Добавили эту строку
    files.forEach(uploadFile)
    files.forEach(previewFile)
}
function uploadFile(file) {
    let url = 'ВАШ URL ДЛЯ ЗАГРУЗКИ ФАЙЛОВ'
    let formData = new FormData()
    formData.append('file', file)
    fetch(url, {
        method: 'POST',
        body: formData
    })
        .then(progressDone) // <- Добавим вызов `progressDone` здесь
        .catch(() => { /* Ошибка. Сообщаем пользователю */ })
}
let uploadProgress = []
function initializeProgress(numFiles) {
    progressBar.value = 0
    uploadProgress = []
    for (let i = numFiles; i > 0; i--) {
        uploadProgress.push(0)
    }
}
function updateProgress(fileNumber, percent) {
    uploadProgress[fileNumber] = percent
    let total = uploadProgress.reduce((tot, curr) => tot + curr, 0) / uploadProgress.length
    progressBar.value = total
}
function uploadFile(file, i) { // <- Добавили параметр `i`
    var url = 'ВАШ URL ДЛЯ ЗАГРУЗКИ ФАЙЛОВ'
    var xhr = new XMLHttpRequest()
    var formData = new FormData()
    xhr.open('POST', url, true)
    // Добавили следующие слушатели
    xhr.upload.addEventListener("progress", function (e) {
        updateProgress(i, (e.loaded * 100.0 / e.total) || 100)
    })
    xhr.addEventListener('readystatechange', function (e) {
        if (xhr.readyState == 4 && xhr.status == 200) {
            // Готово. Сообщаем пользователю
        }
        else if (xhr.readyState == 4 && xhr.status != 200) {
            // Ошибка. Сообщаем пользователю
        }
    })
    formData.append('file', file)
    xhr.send(formData)
}
