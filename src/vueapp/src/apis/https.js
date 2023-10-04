const errorHandle = (status, msg) => {
    switch(status){
        case 400:
            alert('login fail');
            break;
        default:
            alert('option error');
    }
}