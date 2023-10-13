using System;
using webshop.Shared;
namespace webshop.Server.Repositories
{
	public interface IBikeRepository
	{
		BEBike[] GetAll();
		void Add(BEBike bike);
		void DeleteById(int id);
	}
}

