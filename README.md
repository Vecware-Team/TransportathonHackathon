# TransportathonHackathon

## TransportathonHackathon Bir Uluslararası Taşımacılık Uygulamasıdır

### BİLGİLENDİRME

- <b> Bu proje, BEŞİR FATİH DAĞ ve İSMAİL KAYGISIZ tarafından geliştirilmiştir.</b>

- <b> [Bu Adresten Siteye Gidebilirsiniz](https://transportathon.web.app/) </b>

- <b> [Bu Adresten API ye Gidebilirsiniz](https://vecwareteam.somee.com/swagger/index.html) </b>

---

### İLETİŞİM

- İSMAİL KAYGISIZ

  - [Linkedin](https://www.linkedin.com/in/ismail-kaygisiz-a39174200/)
  - [Github](https://github.com/ismailkaygisiz)
  - [Web Site](https://ismailkaygisiz.github.io/)
  - kaygisizismail24@gmail.com

- BEŞİR FATİH DAĞ

  - [Linkedin](https://www.linkedin.com/in/fatih-da%C4%9F-b2661020b/)
  - [Github](https://github.com/Dagbfatih)
  - [Web Site](/)
  - dagbfatih@hotmail.com

---

### PROJE DETAYLARI

- ### Sürümler

  - Angular CLI 16.2.1
  - .Net 7

    Paketler ve sürümlerle ilgili ayrıntıyı bilgiye projelerin içinde bulunan `.csproj` dosyalarından ve [dependencies](https://github.com/Vecware-Team/TransportathonHackathon/network/dependencies) üzerinden erişebilirsiniz.

    Angular projesinde kullanılan paketlere ve sürümlere Angular projesinin içinde bulunan `package.json` ve `package-lock.json` dosyalarından erişebilirsiniz.

- ### Uygulamalar

  - <b>Backend</b>

    .Net 7 derleyebilecek herhangi bir geliştirme ortamı.

  - <b>Frontend</b>

    Herhangi bir metin editörü ve Angular CLI derleme araçları.

---

### PROJEYE DETAYLI BAKIŞ

- ### Backend

  - Backend tarafında Onion Architecture, CQRS ve Repository pattern kullanılmıştır.

  - SOLID prensiplerine tamamen uygun bir API tasarlanmıştır.

  - Uygulama yeni özellikler eklemeye açıktır. Yeni bir özellik eklediğinizde sistemdeki hiçbir kodu değiştirmeniz gerekmez.

  - AspNetCore Identity, EntityFrameworkCore, FluentValidation, Mediatr, AutoMapper, Serilog, Swagger, SignalR ve Jwt implementasyonlarını içermektedir.

  - Gelişmiş Repository yapılarıyla başka hiçbir servise bağımlı olmadan query yazabilir nesneleri birleştirebilirsiniz.

  - Gelişmiş Exception yapıları ve gelişmiş bir ExceptionMiddleware içerir.

  - Gelişmiş loglama sistemiyle istediğiniz her dosyada loglama yapabilir ya da hata aldığınızda hatanın otomatik istediğiniz yerlere loglanmasını sağlayabilirsiniz. Sistemde gömülü olarak 2 adet logger gelmektedir. MsSqlLogger ve FileLogger. Sistem yeni logger eklenmesine ya da loglama paketinin değiştirilmesine müsaittir.

    - Core.CrossCuttingConcerns.Logging/
    - Core.Application.Pipelines.Logging/
    - Logger kaydı için Program.cs dosyasını inceleyebilirsiniz.

  - Swagger sayesinde API endpointlerini test edebilirsiniz. Gelişmiş yapısı sayesinde Swagger üzerinden giriş yapıp sisteme istekte bulunabilirsiniz.

  - FluentValidation ile nesneler üzerinde işlem yapmadan önce kontrol sağlayabilirsiniz.

    - Core.Application.Pipelines.Validation/

  - SignalR ile anlık haberleşmeyi sağlayabilir. Bağlı olan istemcileri anında tetikleyebilirsiniz.

    - TransportathonHackathon.Infrastructure.SignalR/

  - Proje CleanCode prensibiyle tasarlanmış olup çirkin ve karmaşık sayılabilecek hiçbir kod satırını içermemektedir. Dosyalar herkesin anlayabileceği seviyede yazılmıştır.

  - AutoMapper sayesinde nesne dönüşümleri kolaylıkla sağlanmıştır.

  - Yetkilendirme tarafında AspNetCore Identity ve Jwt kullanılmıştır.

    - Core.Application.Pipelines.Authorization/

  - Caching altyapısı mevcuttur.

    - Core.Application.Pipelines.Caching/

  - Sistem, bir kod yapısı çalışırken hata vermesi durumunda yapılan işlemi geri alabilecek yapıya sahiptir.

    - Core.Application.Pipelines.Transaction/

  - Pagination (sayfalama) altyapısını içermektedir ve mesajlaşma sistemi de dahil olmak üzere pek çok yerde kullanılmaktadır.

  - Extension metodlar ile sistem; eskisinden daha güçlü, temiz ve sürdürülebilir.

  - Sınıflar; ServiceCollection, ServiceProvider ve interfaceler sayesinde hiçbir yerde hiçbir nesneye bağımlı değil. Sistemi her şeyden güçlü yapan özelliği, Polymorphism (çok biçimlilik) yapısını neredeyse her yerde içermesidir.

  - Constructor ve ServiceTool aracılığıyla yapılan DependencyInjection (bağımlılık enjeksiyonu) sistemdeki bağımlılığı minimuma indirirken sürdürülebilirliği maksimum düzeye çıkarmaktadır.

  - FakePaymentService ve FakeDriverLicenseVerifier yapılarını içermektedir. Sistem ileride gerçek ödeme ve gerçek doğrulama servisi eklenebilir şekilde tasarlanmıştır. Bağımlılık sıfıra yakın düzeydedir.

    - TransportathonHackathon.Infrastructure.Payment/
    - TransportathonHackathon.Infrastructure.DriverLicenseVerifiers/

  - Anlık mesajlaşma sistemini içermektedir.

  - İş kuralları için yazılmış özel soyut sınıf ve extension metodlar bulunmaktadır.

    - Core.Application.Rules/
    - TransportathonHackathon.Application.Extensions/

  - Sistemde default olarak 6 adet gömülü PipelineBehavior gelmektedir.

  - Sistem çoklu dil desteğini içermektedir.

  - İlişkisel veritabanına sahiptir. Veritabanı tarafında SQL Server kullanılmıştır.

  - Configuration dosyaları ayrılarak Context dosyası daha temiz ve okunabilir hale getirilmiştir. Her bir veritabanı nesnesi configuration dosyalarında detaylı olarak işlenmiştir.

  - Bu projede CodeFirst yaklaşımı sergilenmiştir. Önce nesneler tasarlanıp daha sonra EntityFrameworkCore aracılığıyla otomatik olarak veritabanı oluşturulmuştur.

  - `appsettings.json` dosyası ile harici konfigürasyon verileri dışarıdan değiştirilebilecek şekilde sisteme eklenmiştir.

- ### Frontend

  - Her ne kadar Angular ile çalışılmış olsa da sistem ek istemcilere müsaittir

    - React, Vue.js, ReactNative, Flutter vb.
    - İstenilirse mobil veya masaüstü bir arayüz eklenebilir.

  - SOLID prensiplerine tamamen uygun bir istemci tasarlanmıştır.

  - Uygulama yeni özellikler eklemeye açıktır. Yeni bir özellik eklediğinizde sistemdeki hiçbir kodu değiştirmeniz gerekmez.

  - Font Awesome, Jquery, Bootstrap ve NgxToastr yapılarını içermektedir.

    - Ayrıntılı bilgi için `package.json` dosyasını inceleyebilirsiniz.

  - Http isteği gönderilirken araya girip değişiklik yapabilecek ya da hata yakalayabilecek interceptor yapılarını içermektedir.

  - Bazı adresler için guard koruması bulunmaktadır. Yetkisiz kullanıcılar bu adreslere erişemezler.

  - SignalR sayesinde sunucuyla anında iletişime geçebilir.

  - Angularla default olarak gelen dependency injection ve servis yapılanmasını kullanmaktadır.

  - Angular Forms pek çok yerde işlevsel olarak kullanılmıştır.

  - Admin panel ve şirket yönetim panelini içermektedir.

---

### SİTEYE DETAYLI BAKIŞ

- ### Kullanıcılar ve Sistemde Hazır Gelenler

  - Sistemde test amaçlı 1 admin 2 müşteri 2 şirket 7 sürücü 7 çalışan (sürücü haricinde) ve 6 araç gelmektedir.

  - Sistemde Türkçe ve İngilizce dil destekleri hazır olarak gelmektedir.

  - Sistemde rol ve claim bazlı yetkilendirme sistemi bulunmaktadır ve aktif olarak kullanılmaktadır.

  ***

  - Kullanıcı Bilgileri

  ```json
  {
    "Admin": {
      "userName": "admin",
      "email": "admin@admin.com",
      "password": "Admin@123"
    },
    "Şirket 1": {
      "userName": "company1",
      "email": "company1@company1.com",
      "password": "Company@123"
    },
    "Şirket 2": {
      "userName": "company2",
      "email": "company2@company2.com",
      "password": "Company@123"
    },
    "Müşteri 1": {
      "userName": "customer1",
      "email": "customer1@customer1.com",
      "password": "Customer@123"
    },
    "Müşteri 2": {
      "userName": "customer2",
      "email": "customer2@customer2.com",
      "password": "Customer@123"
    }
  }
  ```

  Şirket1 kullanıcısına ait 5 sürücü 2 çalışan ve 5 araç bulunmaktadır.

  Şirket2 kullanıcısına ait 2 sürücü 3 çalışan ve 1 araç bulunmaktadır.

- ### İşleyiş

  - Sisteme şirket olarak ya da müşteri olarak kullanıcılar kaydolabilir.

    Sürücü ve çalışanları ise sadece şirketler ekleyebilir

  - Müşteriler şirketlerden herhangi birini seçip doğrudan nakliyat talebi gönderebilir ya da şirketle önce iletişime geçerek bilgi alıp daha sonra nakliyat talebi gönderebilirler.

  - Şirketler kullanıcılardan gelen nakliyat taleplerini değerlendirip nakliyat için araç tanımlaması yaptıktan ve fiyat talebini belirttikten sonra nakliyat taleplerini onaylayıp kullanıcıya ödeme talebi gönderebilir.

  - Kullanıcılar ödeme talebi geldikten sonra ödeme yapabilir veya nakliyat talebini kapatabilirler.

  - Kullanıcı ödemeyi yaptıktan sonra iş tamamlandığında nakliyat taleplerim sayfasından tamamlandı olarak işaretleyip nakliyat talebini kapatabilir.

  - Nakliyat talebi bittikten sonra şirketin sayfasına girip seçtiği nakliyat talebi için yorum ekleyebilir ya da diğer kullanıcıların şirket hakkında yaptığı yorum ve değerlendirmeleri görebilir. Bu sayfadan şirket ve çalışanlar hakkında detaylı bilgi alabilir.

  - Müşteriler şirketlerle doğrudan iletişime geçebilir.

  - Şirketlerin kendilerine ait özel yönetim panelleri bulunmaktadır. Bu panelden çalışan ya da araç eklemesi yapabilir gelen nakliyat taleplerini görüntüleyip değerlendirebilirler.

  - Admin kullanıcısının kendine özel paneli bulunmaktadır. Dil, çeviri ve nakliyat tipi ekleyebilir; Sistemdeki müşterileri görüntüleyebilir.

  - `Önemli Not` : Ödeme sayfasında CVV, Month ve Year değerleri 0 ile başlayamaz. Month değeri 2 haneli CVV 3 haneli ve Year ise 4 haneli olmak zorundadır. Değiştirmeye vaktimiz kalmadığı için böyle kaldı.

  ***

- ## SİTEDEN GÖRÜNTÜLER

![HomePage](https://github.com/Vecware-Team/TransportathonHackathon/blob/main/GithubImages/Home_Page.png?raw=true)

![Companies](https://github.com/Vecware-Team/TransportathonHackathon/blob/main/GithubImages/Companies_Page.png?raw=true)

![TransportRequests](https://github.com/Vecware-Team/TransportathonHackathon/blob/main/GithubImages/Transport_Requests_Page.png?raw=true)

![Messages](https://github.com/Vecware-Team/TransportathonHackathon/blob/main/GithubImages/Messages_Page.png?raw=true)

![CompanyDetails](https://github.com/Vecware-Team/TransportathonHackathon/blob/main/GithubImages/Company_Details_Page.png?raw=true)

![CreateTransportRequest](https://github.com/Vecware-Team/TransportathonHackathon/blob/main/GithubImages/Create_Transport_Request_Page.png?raw=true)

![CustomerDetails](https://github.com/Vecware-Team/TransportathonHackathon/blob/main/GithubImages/Customer_Profile_Page.png?raw=true)

![Settings](https://github.com/Vecware-Team/TransportathonHackathon/blob/main/GithubImages/Settings_Page.png?raw=true)

![CompanyManage1](https://github.com/Vecware-Team/TransportathonHackathon/blob/main/GithubImages/Company_Manage_Page_1.png?raw=true)

![CompanyManage2](https://github.com/Vecware-Team/TransportathonHackathon/blob/main/GithubImages/Company_Manage_Page_2.png?raw=true)

![CompanyManage3](https://github.com/Vecware-Team/TransportathonHackathon/blob/main/GithubImages/Company_Manage_Page_3.png?raw=true)

![Admin1](https://github.com/Vecware-Team/TransportathonHackathon/blob/main/GithubImages/Admin_Page_1.png?raw=true)

![Admin2](https://github.com/Vecware-Team/TransportathonHackathon/blob/main/GithubImages/Admin_Page_2.png?raw=true)

![Admin3](https://github.com/Vecware-Team/TransportathonHackathon/blob/main/GithubImages/Admin_Page_3.png?raw=true)

![Admin4](https://github.com/Vecware-Team/TransportathonHackathon/blob/main/GithubImages/Admin_Page_4.png?raw=true)

![AboutUs](https://github.com/Vecware-Team/TransportathonHackathon/blob/main/GithubImages/Aboutus_Page.png?raw=true)


![Swagger](https://github.com/Vecware-Team/TransportathonHackathon/blob/main/GithubImages/Aboutus_Page.png?raw=true)
