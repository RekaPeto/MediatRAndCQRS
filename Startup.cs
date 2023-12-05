using MediatR;
using MediatRAndCQRS.Mapping;
using MediatRAndCQRS.Repositories;

namespace MediatRAndCQRS
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddSwaggerGen();

			services.AddSingleton<ICustomersRepository, CustomerRepository>();
			services.AddSingleton<IOrdersRepository, OrderRepository>();
			services.AddSingleton<IMapper, Mapper>();
			services.AddMediatR(typeof(Startup));

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}


			app.UseSwagger();
			app.UseSwaggerUI();


			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
