using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore;
using Shared_Static_Class.DB_Context_Vivo_MAIS;
using Shared_Static_Class.Data;

namespace Shared_Razor_Components.FundamentalModels
{
    public partial class SequentialGuidGenerator : ValueGenerator<Guid>
    {
        private long _sequence;

        public override bool GeneratesTemporaryValues => false;

        public override Guid Next(EntityEntry entry)
        {
            if (_sequence == 0)
            {
                var maxIndex = entry.Context.Set<DEMANDA_RELACAO_CHAMADO>().Count();
                _sequence = maxIndex + 1;
            }
            else
            {
                _sequence++;
            }

            byte[] sequenceBytes = BitConverter.GetBytes((ushort)_sequence);

            byte[] guidBytes = new byte[16];
            Buffer.BlockCopy(sequenceBytes, 0, guidBytes, 0, 2);

            Guid randomGuid = Guid.NewGuid();
            byte[] randomBytes = randomGuid.ToByteArray();
            Buffer.BlockCopy(randomBytes, 0, guidBytes, 2, 12);

            return new Guid(guidBytes);
        }
    }

}