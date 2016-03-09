### Bu �rnek kodun amaci Angular JS de Login Gereken durumlarda sayfay� y�nlendirmek.
Asp.net Web Form kullarak web geli�tirmeye ba�lam�� biri olarak orada ilk oturum y�netme mant���m session kontrol edip e�er session null ise response.redirect ile kullan�c�y� oturum a�ma/�ye olma sayfas�na y�nlendirmekti.
Angularjs kullanmaya ba�lay�nca da ilk olarak bunu nas�l yapar�m diye ararken http://www.c-sharpcorner.com/UploadFile/ff2f08/token-based-authentication-using-Asp-Net-web-api-in-angularj/
adresinde ki �rnekte istedi�im buldum ve bir web api 2 ile �rnek yap�p buraya koydum.
�rnekte 2 tane controller var birisi defaultController di�eri DefaultController2
DefaultController anonim isteklere veri g�nderirken Default2Controller Authorize Attribute i�erdi�i i�in 401 hatas� d�nd�rmekte 
cok az kod barindirmasi i�inde projede angularjs Core ,index.html ve login/index.html dosyalar� i�eriyor. �rnek de de �nemli olan k�s�m a�a��daki k�s�md�r.


    .config(['$httpProvider', function ($httpProvider) {  
  
        $httpProvider.interceptors.push(function ($q, $rootScope, $window, $location) {  
  
            return {  
                request: function (config) {  
  
                    return config;  
                },  
                requestError: function (rejection) {  
  
                    return $q.reject(rejection);  
                },  
                response: function (response) {  
                    if (response.status == "401") {  
                        $location.path('/login');  
                    }  
                    //the same response/modified/or a new one need to be returned.  
                    return response;  
                },  
                responseError: function (rejection) {  
  
                    if (rejection.status == "401") {  
                        $location.path('/login');  
                    }  
                    return $q.reject(rejection);  
                }  
            };  
        });  
    }]);  