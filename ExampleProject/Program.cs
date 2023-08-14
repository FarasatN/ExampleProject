using System.Configuration;
using ExampleProject.AutoMappers;
using ExampleProject.Extensions;
using ExampleProject.Handlers;
using ExampleProject.Models;
using ExampleProject.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
//servisler builder uzerinden integrasiya edilir
//burdan IServicesCollectiona access edirik
//ConfigurationManageri da buradan add edilir (appsettings.json,env variables) - artiq xarici json konf+i da bu class vasitesile rahat edirik
//Console.WriteLine(builder.Configuration["Conf:A"]);//ConfigurationManager


builder.Services.AddControllersWithViews().AddFluentValidation(x=>x.RegisterValidatorsFromAssemblyContaining<Program>());
builder.Services.AddCors(/*..*/);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();
builder.Services.AddOutputCache();
builder.Services.AddAutoMapper(typeof(PersonelProfil));


//DI
//Add - default olaraq singleton elave edir,eger parametrde qeyd olunmayibsa
//builder.Services.Add(new ServiceDescriptor(typeof(ConsoleLog), new ConsoleLog()));
//builder.Services.Add(new ServiceDescriptor(typeof(TextLog), new TextLog()));
//builder.Services.AddSingleton<ConsoleLog> ();//bununla constructorunda parametr olanda islemeyecek, bununcun
//builder.Services.AddSingleton<ConsoleLog>(p => new ConsoleLog("abc"));//digerler de eyni qaydada olacaq

//interface uzerinden
builder.Services.AddScoped<ILog,ConsoleLog>(p => new ConsoleLog("abc"));
//builder.Services.AddScoped<ILog,TextLog>(p => new TextLog());
//controllerden bunlari elde etmek ucun ise onlarin constructorundan ist. etmekdir

//Area- esasen admin ve diger view hisselerini bir birinden ayirmaq ucundur

//ViewModel ve DTO 
//Validationlar viewmodel de olmalidir

//Data mapping:
//Manuel
//Implicit
//Explicit
//AutoMapper
//Reflection


//appsettings.json
//IConfiguration  interface uzerinden access edirik
//Indexer ile settings oxumaq


//Options Pattern ile konfiqurasuyalari Dependency Injection ile konfiqurasiya etme
builder.Services.Configure<MailInfo>(builder.Configuration.GetSection("MailInfo"));

//Secret manager Tools - biz hessas konfiqurasiyalari secret.jsonda tuturuq, user-password, connection string ve s.
//basqasinin eline kecmemesi ucun
//secret.json faylina da ele Configurationdan giris edirik
//appsettings ile yeni isleyir, oncelik meselesi var, birinci environmente baxir, sonra secrete, sonra da appsettinf=gse'

//sqle ozel dagilmis konfiqurasiyalar ucun sql connection builder ile toplamaq olur


//Environment
//IWebEnvironment ile Runtime Environment haqqinda 
//env in secre ve appsettingsi ezmesi

//-------------------------------------------------
var app = builder.Build();
//middleware ler ise app uzerinden elave edilir
//IServicesProvider ise buradan 
//IConfiguration- Middlewareler uzerinde konf.el degere ehtiyac varsa ist. edilir
//ConfigurationManager cm = new();
//cm.AddJsonFile("conf.json");
//Console.WriteLine(cm["A"]);

app.UseStaticFiles();
app.UseOutputCache();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();
app.UseCors();


app.UseRouting();
//routing xususiden umumiye gedir

//app.MapControllerRoute("CustomUrl", "{controller=Product}/{action=Index}/{a}/{b}/{id}");
//app.MapControllerRoute("Default", "{action}/{controller}");//yerlerini deyisib custom yaza bilerik

//app.MapControllerRoute("Default3", "{controller=Home}/{action=Index}/{id?}/{x?}/{y?}");//parametri de string olaraq tutmaq daha dogrudur


//normalda bele ist. olunur
//app.MapControllerRoute("Default","{controller=Personal}/base/{action=Index}");//bos deyer gondersen xeta evrecek
//app.MapControllerRoute("Default2", "homepage", new { controller = "Product", action = "c" });

app.MapDefaultControllerRoute();//default olaraq homun altinda index calisacaq, ?id=2 kimi ancaq destek var
								//.CacheOutput();
								//home/index/5 ezib personel/name/ahmet ede bilirik

//Route Constraints - mueyyen olunmus tipden basqa tipde deyer yazmaga icaze vermir
//{id:int?}
//eger tip qeyd olunmayibsa string kimi goturmek olar istenilen deyeri
//int ve string adeten ist. olunur
//{x:length(6)?}//maxlength,range,min ve s.
//bundan elave custom constraint de yarada bilerik

//Attribute Routing - routelarin hamisini tek bir yere yiga bilerik - control based routing
//bu yolla program faylina bir bir elave etmirik routlari
//bunun ucun butun MapRoutingin yerine MapControllers yazilir

//app.MapControllers();

//Custom Route Handler - gundelik fealiyetde ehtiyac olmur
//app.Map("example-route",async c =>
//{
//    //endpointe gelen herhansi request controllora getmeden burada funksiya terefinden cagirila bilecek
//});
//isi ayrica classa cixardiriq
//app.Map("example-route", new ExampleHandler().Handler());
app.Map("image/{fileName}", new ImageHandler().Handler(builder.Environment.WebRootPath));



//Middleware - request ile response arasina girib istediyimiz kimi mudaxile ede bilmedir
//controllere qeder ve hetta ondan sonra da middleware ler olur
//middleware ler sarmal sekilde calisir - recursive kimi, ic-ice

//app... olan her sey eslinde bir middlewaredir - Configure metodu icerisinde
//butun middleware ler Use... ile baslayar
//cagirilma radicilligi cox onemlidir
//Hazir Middleware ler: Run, Map, Use, MapWhen
//Run- ozunden sonra gelen middlewareni cagirmir - Short Circuit

//Use
//app.Use(async (context, next) =>
//{
//	Console.WriteLine("Start use middleware");
//	 await next.Invoke();//sonrakini invoke ederek calisir
//	Console.WriteLine("Stop use middleware");

//});

//Map,MapWhen - filterlemek ucun ist. olunur
//Map endpointin ancaq pathine gore
//MapWhende is istenilen bir ozelliyine gore
//app.UseHello();

//Dependency Inversion - Dependency Injectionun ters cevrilmis halidir,asililiqlari ters cevir
//Dependency Injection - asan izahda- bir nece clasda basqa bir classin instanci yaradilir, elbette her defe ne edirik buna gore,eger instanci yaradilacaq classda deyisiklik olarsa,biz mecbur tek tek her yerde deyismeliyik bunun ucun,yaxud evezine basqa classin instanci yaranacaq,  bunun da qarsisini almaq ucu di tetbiq edilir ve dependencyler ayrica bir yere toplanir ve ordan tetbiq edilir
//bunun ucun bunlarin hamisinin ortaq torediyi bir class,interface olur ve onu constructor,seter method ve s. methodla, yeni parametr olaraq al ve her yerde cagir
//DI - asililiqlari abstractlasdirmaqdir, qopartmaq deyil
//dependencyini tersine cevirmek, asililigi ortadan qaldirmaq Inversion of Control adlanir, asililiqlar bir containerde tutulur
//IoC AspNetCore da default olaraq gelir - built-in
//3rd part frameworks: StructureMap,AutoFac,Ninject
//Built-in IoC Container icerisine qoyulacaq degerleri,obyektleri 3 ferqli davranisla edir
//Singleton,Scoped, Transient
//Singleton - butun appde tek bir instance yaradir
//Scoped - her request basina bir instance yaradir ve reuest pipelineninda olan butun requestler ucun o ist. olunur
//Transient- her requestin her telebine ayrica bir object yaradir
//IServiceCollection bizim bult-in containerimizdir

//Secret Manager Tools -- 

app.Run(
//	async context =>
//{
//	Console.WriteLine("Run middleware");
//}

); //eyni qaydada next olmur bunda






//-------------------------
//http3
//Minimal Api
//Rate Limit- bir zaman diliminde heddinden artiq bir servise ardicil request gondermeyin qarsisini alir
//Output Caching
//SignalR - Client Results feature


