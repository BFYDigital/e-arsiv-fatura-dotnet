### Bu paket [Fatih Kadir Akın](https://github.com/f)'ın hazırlamış olduğu [fatura](https://github.com/f/fatura) paketinin C# dili .NET 5.0 Framework ile yazılmış versiyonudur.

<h1 align="center">C# .NET Core (5.0) e-Arşiv Fatura Oluşturma</h1>
<br />

## Table of Contents

- [Hakkında](#about)
- [Başlangıç](#getting_started)
- [Ayarlar](#configuring)
- [Kullanım](#usage)

## Hakkında <a name = "about"></a>

e-Arşiv Portal'a httpclient üzerinden bağlanma, fatura oluşturma, imzalama, indirme ve görüntüleme işlemleri yapılabilecek .net 5.0 ile yazılmış library uygulamasıdır.

## Başlangıç <a name = "getting_started"></a>
Library uygulamasını indirip (clone) isteğinize göre düzenlemeler yapabilir, derleyebilir ardından oluşan DLL dosyasını projenize başvuru olarak ekleyerek kullanabilirsiniz. Ya da direk çözüm dosyanıza direk proje olarak ekleyerek çalışabilirsiniz.

## Ayarlar <a name = "configuring"></a>
Başvuru olarak eklenen proje de kullanılmak istenen dosyaya aşağıdaki satırları ekleyin.
```
using BFY.Fatura;
using BFY.Fatura.Configuration;
using BFY.Fatura.Models;
```

Kullanmak istediğiniz Fonksiyon içinde aşağıdaki şekilde bir configuration nesnesi üretip kendi bilgilerinizin girişini yapın
```
var configuration = FaturaServiceConfigurationFactory.Create();
configuration.ServiceType = ServiceType.Prod;
configuration.Username = "";
configuration.Password = "";
```

Aşağıdaki şekilde bir servis nesnesi üretin
```
FaturaService faturaService = new(configuration);
```

Bir token alın
```
faturaService.GetToken().Wait();
```

Artık diğer fonksiyonları kullabilirsiniz.


## Kullanım <a name="usage"></a>
Fatura Oluşturma : 
InvoiceDetailsModel tipinden fatura nesnenizi üretin ve bilgilerinizi girin.
```
var response = faturaService.CreateInvoice(nesne, false).GetAwaiter().GetResult();
```

Fatura listesini getirme :
```
var faturalar = faturaService.GetAllInvoicesByDateRange(DateTime.Now, DateTime.Now).GetAwaiter().GetResult();
```

Tek bir fatura için HTML görüntüleme :
```
var html = faturaService.GetInvoiceHTML(item.ettn).GetAwaiter().GetResult();
```


## Lisans
MIT

----

> ☢️ **BU PAKET VERGİYE TABİ OLAN MALİ VERİ OLUŞTURUR.** BU PAKET NEDENİYLE OLUŞABİLECEK SORUNLARDAN BU PAKET SORUMLU TUTULAMAZ, RİSK KULLANANA AİTTİR. RİSKLİ GÖRÜYORSANIZ KULLANMAYINIZ.




