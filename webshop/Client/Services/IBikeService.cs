using System;
using webshop.Shared;
namespace webshop.Client.Services
{
	public interface IBikeService
	{
		Task<IEnumerable<BEBike>> GetAll();

		Task AddBike(BEBike bike);
	}
}
