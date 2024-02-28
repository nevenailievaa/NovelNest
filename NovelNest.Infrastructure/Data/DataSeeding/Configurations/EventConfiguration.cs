using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NovelNest.Infrastructure.Data.Models.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NovelNest.Infrastructure.Data.Models.Events;

namespace NovelNest.Infrastructure.Data.DataSeeding.Configurations
{
    internal class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            var data = new DataSeed();

            builder.HasData(new Event[] { data.EventSofiasEtudes, data.EventAlbertBenbasat, data.EventTotalitarism });
        }
    }
}
