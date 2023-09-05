const picker = document.getElementById('dateof');
picker.addEventListener('input', function (e) {
    var day = new Date(this.value).getUTCDay();
    if ([6, 0].includes(day)) {
        e.preventDefault();
        this.value = '';
        alert('Weekends not allowed');
    }
});

window.onload = function () {
    var workCheckbox = document.querySelectorAll('.employedCheckbox');
    var workTelDiv = document.querySelectorAll('.workTelDiv');
    var workEmailDiv = document.querySelectorAll('.workEmailDiv');


    for (let i = 0; i < workTelDiv.length; i++) {
        workCheckbox[i].addEventListener('change', function () {
            if (workCheckbox[i].checked) {
                workTelDiv[i].style.display = 'block';
                workEmailDiv[i].style.display = 'block';
            } else {
                workTelDiv[i].style.display = 'none';
                workEmailDiv[i].style.display = 'none';
            }
        });
    }


    // Trigger change event to set initial visibility
    checkbox.dispatchEvent(new Event('change'));
};