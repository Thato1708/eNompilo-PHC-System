const picker = document.getElementById('dateof');
/*const timePicker = document.getElementById('timeof');*/

picker.addEventListener('input', function (e) {
    var day = new Date(this.value).getUTCDay();
    if ([6, 0].includes(day)) {
        e.preventDefault();
        this.value = '';
        alert('Weekends not allowed');
    }
});

//timePicker.addEventListener('input', function (e) {
//    var time = new TimeRanges(this.value).getUTCHours();
//    if ([0, 1, 2, 3, 4, 5, 6, 7, 16, 17, 18, 19, 20, 21, 22, 23].includes(time)) {
//        e.preventDefault();
//        this.value = '';
//        alert('Booking slot not available within this hour. Check between 08h00 and 15h00');
//    }
//});

