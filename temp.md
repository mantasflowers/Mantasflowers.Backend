# JSON DI and interceptors

## 1 - Custom minimal autofac registration via JSON
Turime JSON [formatą](src/Mantasflowers.WebApi/autofacCustom.json), kuris leidžia registruoti bet kokį _business layer_ komponentą (mūsų panaudojimo atvėjui). Registracijos kodas: [CustomAutofacSetup.cs](/src/Mantasflowers.WebApi/Setup/DI/CustomAutofac/CustomAutofacSetup.cs).

Kaip POC, yra užregistruotas [ProductReviewService](src/Mantasflowers.Services/Services/Review/ProductReviewService.cs), kuris turi savo antrininką po tuo pačiu interface: [DummyProductReviewService](src/Mantasflowers.Services/Services/Review/ProductReviewService.cs) (demo tikslais).

Įdomus aspektas, kad JSON registracija įvyksta po visų kitų **kodo** registracijų (žr. [Startup.cs](src/Mantasflowers.Webapi/Startup.cs) 108 eilutę) ir *autofac* to pačio tipo registracijas perrašo ant viršaus. Tai reiškia, kad jei norime pakeisti kažkokį komponentą (net ir tą kuris nebuvo užregistruotas per JSON), tai galime padaryti.

### Klausimai:
1. Ar toks POC jau pilnai tenkintų reikalavimą? T.y., nors dabar techniškai galėtume visą *business layer* suregistruoti, ar užtenka tik vienos registracijos kaip pavyzdžio?
2. Ar demo tikslais užtenka turėti tokį *Dummy* komponentą, ar tai vis dėlto turi būti logiška iš *business logikos* pusės?  

<br>

## 2 - Interceptors, logging and JSON autofac
Reikalvimas dėl interceptorių mini, jog reikia turėti galimybė išjungti/įjungti/pakeisti neperkopiliuojant ir galbūt tik modifikuojant konfiguracinį failą. Mūsų atvėju tai labai glaudžiai susiję su DI. Kaip jau minėjau prieš tai, kadangi JSON registracija vyksta paskutinė, yra galimybė perrašyti ankščiau užregistruotus komponentus (o tai reiškia pakeisti ir jų interceptorius).

### Pvz.:
Turime komponentą kuris yra užregistruotas kode (gali būti registruotas ir JSON):
```csharp
builder.RegisterType<ProductService>()
    .As<IProductService>()
    .EnableInterfaceInterceptors()
    .InterceptedBy(typeof(AsyncInterceptorAdapter<MethodCallInterceptorAsync>))
    .InstancePerLifetimeScope();
```

Tuomet savo JSON faile galime rašyti (šiuo atvėju išjungiame vieną visus interceptorius):
```json
{
    "type": "Mantasflowers.Services.Services.Product.ProductService, Mantasflowers.Services",
    "interfaces": [
    {
        "type": "Mantasflowers.Services.Services.Product.IProductService, Mantasflowers.Services"
    }
    ],
    "interceptors": []
    "scope": "perlifetimescope"
}
```

### Klausimai:
1. Ar to užtektų šiai šio reikalavimo daliai patenkinti?