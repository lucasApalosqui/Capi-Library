using CapiLibrary.Models;
using CapiLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CapiLibrary.Endpoints
{
    public static class AddressEndpoint
    {
        public static void Create(string street, string district, string state, int number, string complement, int IdUser)
        {
            try
            {
                Repository<AddressTable> repo = new Repository<AddressTable>();
                AddressTable addressTable = new AddressTable();
                addressTable.Street = street;
                addressTable.District = district;
                addressTable.State = state;
                addressTable.Number = number;
                addressTable.Complement = complement;
                addressTable.IdUser = IdUser;

                repo.Create(addressTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao cadastrar o Endereço: {ex.Message}");
            }
        }

    }
}
