# TransportathonHackathon

## TransportathonHackathon Bir Uluslararası Taşımacılık Uygulamasıdır

### BİLGİLENDİRME

- <b> Bu proje, BEŞİR FATİH DAĞ ve İSMAİL KAYGISIZ tarafından geliştirilmiştir.</b>

- <b> [Bu Adresten Siteye Gidebilirsiniz]() </b>

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

  - SignalR ile anlık haberleşmeyi sağalayabilir. Bağlı olan istemcileri anında tetikleyebilirsiniz.

    - TransportathonHackathon.Infrastructure.SignalR/

  - Proje CleanCode prensibiyle tasarlanmış olup çirkin ve karmaşık sayılabilecek hiçbir kod satırını içermemektedir. Dosyalar herkesin anlayabileceği seviyede yazılmıştır.

  - AutoMapper sayesinde nesne dönüşümleri kolaylıkla sağlanmıştır.

  - Yetkilendirme tarafında AspNetCore Identity ve Jwt kullanılmıştır.

    - Core.Application.Pipelines.Authorization/

  - Caching altyapısı mevcuttur.

    - Core.Application.Pipelines.Caching/

  - Sistem bir kod yapısı çalışırken hata vermesi durumunda yapılan işlemi geri alabilecek yapıya sahiptir.

    - Core.Application.Pipelines.Transaction/

  - Pagination (sayfalama) altyapısını içermektedir ve mesajlaşma sistemi de dahil olmak üzere pek çok yerde kullanılmaktadır.

  - Extension metodlar ile eskisinden daha güçlü, temiz ve sürdürülebilir.

  - Sınıflar; ServiceCollection, ServiceProvider ve interfaceler sayesinde hiçbir yerde hiçbir sınıfa bağımlı değil. Sistemi her şeyden güçlü yapan, Polymorphism (çok biçimlilik) yapısını neredeyse her yerde içermesidir.

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
