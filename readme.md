### Bu Örnek kodun amaci Angular JS de Login Gereken durumlarda sayfayý yönlendirmek.
Asp.net Web Form kullarak web geliþtirmeye baþlamýþ biri olarak orada ilk oturum yönetme mantýðým session kontrol edip eðer session null ise response.redirect ile kullanýcýyý oturum açma/Üye olma sayfasýna yönlendirmekti.
Angularjs kullanmaya baþlayýnca da ilk olarak bunu nasýl yaparým diye ararken http://www.c-sharpcorner.com/UploadFile/ff2f08/token-based-authentication-using-Asp-Net-web-api-in-angularj/
adresinde ki örnekte istediðim buldum ve bir web api 2 ile örnek yapýp buraya koydum.
Örnekte 2 tane controller var birisi defaultController diðeri DefaultController2
DefaultController anonim isteklere veri gönderirken Default2Controller Authorize Attribute içerdiði için 401 hatasý döndürmekte 
cok az kod barindirmasi içinde projede angularjs Core ,index.html ve login/index.html dosyalarý içeriyor. Örnek de de Önemli olan kýsým aþaðýdaki kýsýmdýr.


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