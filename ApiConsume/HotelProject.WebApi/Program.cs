using HotelProject.BusinnessLayer.Abstract;
using HotelProject.BusinnessLayer.Concrete;
using HotelProject.DataAccsessLayer.Abstract;
using HotelProject.DataAccsessLayer.Concrete;
using HotelProject.DataAccsessLayer.Entityframework;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Context>();

builder.Services.AddScoped<IStaffDal, EFStaffDal>();
builder.Services.AddScoped<IStaffService, StaffManager>();

builder.Services.AddScoped<IServicesDal, EFServiceDal>();
builder.Services.AddScoped<IServicesService, ServiceManager>();

builder.Services.AddScoped<IRoomDal, EFRoomDal>();
builder.Services.AddScoped<IRoomService, RoomManager>();

builder.Services.AddScoped<ITestimonialDal, EFTestimonailDal>();
builder.Services.AddScoped<ITestimonailService, TestimonialManager>();

builder.Services.AddScoped<ISubscribesDal, EFSubscribesDal>();
builder.Services.AddScoped<ISubscribeService, SubscribesManager>();

builder.Services.AddScoped<IAboutUsService, AboutUsManager>();
builder.Services.AddScoped<IAbouUsDal, EFAboutDal>();

builder.Services.AddScoped<IBookingService, BookingManager>();
builder.Services.AddScoped<IBookingDal, EFBookingDal>();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("OtelApiCors", opts =>
    {
        opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("OtelApiCors");
app.UseAuthorization();

app.MapControllers();

app.Run();
