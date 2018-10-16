var guid = generateGUID();
//alert(guid);
function AlertInfo() {
    var elements = document.getElementsByClassName("current-file");
    var progressBar = document.getElementById("progressBar");
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        url: "http://localhost:8080/TestService/ParseService.svc/StartParseFiles?ID="+guid,
        success: function () {
            var myInterval = setInterval(function () {
                $.ajax({
                    type: "GET",
                    datatype: "json",
                    //data:JSON.stringify(myData),
                    contentType: "application/json; charset=utf-8",
                    url: "http://localhost:8080/TestService/ParseService.svc/giveStatusInfoParse?ID="+guid,
                    success: function (result) {
                        if(result.isSuccessful === false){
                            console.log(result.ExceptionMessage);
                        }  
                        else{                
                            if (result.Info.currentFile == result.Info.fileCount) {
                                clearInterval(myInterval);
                                alert('Количество слов bingo в файлах '+result.Info.matchCount);
                            }
                            console.log('CurrentFile = ' + result.Info.currentFile + ', CurrentFileName = ' + result.Info.currentFileName);                        
                            elements[0].innerHTML = String(result.Info.currentFile);
                            elements[1].innerHTML = String(result.Info.currentFile);
                            document.getElementById("All-Files").innerHTML = result.Info.fileCount;
                            document.getElementById("Name-of-current-file").innerHTML = result.Info.currentFileName;
                            $("#progressBar").animate({"value":String((result.Info.currentFile/result.Info.fileCount)*100)},200);
                        }
                        
                    }
                })
            }
                , 200);
        }
    });
}

function S4() {
    return (((1+Math.random())*0x10000)|0).toString(16).substring(1); 
}
function generateGUID(){
    return (S4() + S4() + "-" + S4() + "-4" + S4().substr(0,3) + "-" + S4() + "-" + S4() + S4() + S4()).toLowerCase();
}
 

function Cancel() {
    clearInterval(myInterval);
}