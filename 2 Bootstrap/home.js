function f() {
    let name = document.getElementById("InputName").value;
    let students = document.getElementById("InputStudents").value;
    let email = document.getElementById("InputEmail").value;

    // if (students > 1000) {
    //     $('#exampleModalCenter').modal({
    //         keyboard: true
    //       });
    // };

    document.getElementById('tbody').innerHTML += '<tr><td>' + name + '</td><td>' + students + '</td><td>' + email + '</td></tr>';
}

// if (alertTrigger) {
//     alertTrigger.addEventListener('click', function () {
//         alert('Nice, you triggered this alert message!', 'success')
//     })
// }

// var alertPlaceholder = document.getElementById('liveAlertPlaceholder')
// var alertTrigger = document.getElementById('liveAlertBtn')

// function alert(message, type) {
//     var wrapper = document.createElement('div')
//     wrapper.innerHTML = '<div class="alert alert-' + type + ' alert-dismissible" role="alert">' + message + '<button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button></div>'

//     alertPlaceholder.append(wrapper)
// }