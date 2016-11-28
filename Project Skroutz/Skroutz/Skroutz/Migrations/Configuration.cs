namespace Skroutz.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Skroutz.DAL;
    using Skroutz.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Skroutz.DAL.SkroutzContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SkroutzContext context)
        {
            /*
             * Categories 
             */
            context.Categories.AddOrUpdate(x => x.Name,
                new Category { Name = "Computers" },
                new Category { Name = "Entertainment" },
                new Category { Name = "Gaming" }
            );
            context.SaveChanges();
            int computers_id = context.Categories.Where(x => x.Name == "Computers").Select(x => x.Id).SingleOrDefault();
            int entertainment_id = context.Categories.Where(x => x.Name == "Entertainment").Select(x => x.Id).SingleOrDefault();
            int gaming_id = context.Categories.Where(x => x.Name == "Gaming").Select(x => x.Id).SingleOrDefault();
            context.Categories.AddOrUpdate(x => x.Name,
                new Category { Name = "Hardware", ParentId = computers_id },
                new Category { Name = "Monitors", ParentId = computers_id },
                new Category { Name = "Televisions & Accessories", ParentId = entertainment_id },
                new Category { Name = "Projectors & Accessories", ParentId = entertainment_id },
                new Category { Name = "Consoles", ParentId = gaming_id },
                new Category { Name = "Virtual Reality Headsets", ParentId = gaming_id }
            );
            context.SaveChanges();
            int hardware_id = context.Categories.Where(x => x.Name == "Hardware").Select(x => x.Id).SingleOrDefault();
            int tvaccessories_id = context.Categories.Where(x => x.Name == "Televisions & Accessories").Select(x => x.Id).SingleOrDefault();
            int projectorsaccessories_id = context.Categories.Where(x => x.Name == "Projectors & Accessories").Select(x => x.Id).SingleOrDefault();
            context.Categories.AddOrUpdate(x => x.Name,
                new Category { Name = "Hard Drives", ParentId = hardware_id },
                new Category { Name = "Graphic Cards", ParentId = hardware_id },
                new Category { Name = "Memory", ParentId = hardware_id },
                new Category { Name = "Processors", ParentId = hardware_id },
                new Category { Name = "Motherboards", ParentId = hardware_id },
                new Category { Name = "Modding & Cooling", ParentId = hardware_id },
                new Category { Name = "Computer Cases", ParentId = hardware_id },
                new Category { Name = "Power Supplies", ParentId = hardware_id },
                new Category { Name = "Optical Drives", ParentId = hardware_id },
                new Category { Name = "TVs", ParentId = tvaccessories_id },
                new Category { Name = "HDMI Cables", ParentId = tvaccessories_id },
                new Category { Name = "TV Brackets", ParentId = tvaccessories_id },
                new Category { Name = "Remote Controls", ParentId = tvaccessories_id },
                new Category { Name = "3D Glasses", ParentId = tvaccessories_id },
                new Category { Name = "Projectors", ParentId = projectorsaccessories_id },
                new Category { Name = "Projector Screens", ParentId = projectorsaccessories_id },
                new Category { Name = "Projector Lamps", ParentId = projectorsaccessories_id }
            );
            context.SaveChanges();
            int harddrives_id = context.Categories.Where(x => x.Name == "Hard Drives").Select(x => x.Id).SingleOrDefault();
            int moddingcooling_id = context.Categories.Where(x => x.Name == "Modding & Cooling").Select(x => x.Id).SingleOrDefault();
            context.Categories.AddOrUpdate(x => x.Name,
                new Category { Name = "Internal Hard Drives", ParentId = harddrives_id },
                new Category { Name = "External Hard Drives", ParentId = harddrives_id },
                new Category { Name = "Hard Disk Frames & Enclosures", ParentId = harddrives_id },
                new Category { Name = "Case Fan", ParentId = moddingcooling_id },
                new Category { Name = "CPU Coolers", ParentId = moddingcooling_id }
                );
            context.SaveChanges();
            int internalhd_id = context.Categories.Where(x => x.Name == "Internal Hard Drives").Select(x => x.Id).SingleOrDefault();
            context.Categories.AddOrUpdate(x => x.Name,
                new Category { Name = "SSDs", ParentId = internalhd_id},
                new Category { Name = "HDDs", ParentId = internalhd_id}
                );
            context.SaveChanges();
            context.Stores.AddOrUpdate(x => x.Name,
                new Store { Name = "Argos", Web = "www.argos.co.uk", Phone = "03456402020" },
                new Store { Name = "BT Shop", Web = "www.shop.bt.com", Phone = "08009170510" },
                new Store { Name = "Currys", Web = "www.currys.co.uk", Phone = "03445610000" },
                new Store { Name = "Electrical Europe", Web = "www.electricaleurope.com/", Phone = "02866335045" },
                new Store { Name = "Electricshop", Web = "www.electricshop.com ", Phone = "01923851411" },
                new Store { Name = "PC World", Web = "www.pcworld.co.uk", Headquarters = "20 Chiswell St, London EC1Y 4TW, UK", Phone = "03445610000" },
                new Store { Name = "Hughes", Web = "www.hughes.co.uk", Headquarters = "Hughes Electrical, 259 Felixstowe Rd, Ipswich, Suffolk IP3 9BN, UK", Phone = "03712313113" },
                new Store { Name = "Sonic Direct", Web = "www.sonicdirect.co.uk", Headquarters = "Ingleby Rd, Bradford, West Yorkshire BD8 9AN, UK", Phone = "01274575000" },
                new Store { Name = "Viking", Web = "www.viking-direct.co.uk", Phone = "08444120000" }
                );
            context.SaveChanges();
            context.Products.AddOrUpdate(x => x.Name,
                new Product { Name = "Transcend MTS400 M.2 32GB", CategoryId = context.Categories.Single(x => x.Name == "SSDs").Id },
                new Product { Name = "Kingston SSDNow 30GB", CategoryId = context.Categories.Single(x => x.Name == "SSDs").Id },
                new Product { Name = "Transcend MSM610 mSATA 16GB", CategoryId = context.Categories.Single(x => x.Name == "SSDs").Id },
                new Product { Name = "Transcend SSD370S 32GB", CategoryId = context.Categories.Single(x => x.Name == "SSDs").Id },
                new Product { Name = "Sandisk ReadyCache 32GB SSD", CategoryId = context.Categories.Single(x => x.Name == "SSDs").Id },
                new Product { Name = "Adata Premier Pro SP600 32GB", CategoryId = context.Categories.Single(x => x.Name == "SSDs").Id },
                new Product { Name = "Sandisk Z400s M.2 256GB", CategoryId = context.Categories.Single(x => x.Name == "SSDs").Id },
                new Product { Name = "Sandisk X400 256GB", CategoryId = context.Categories.Single(x => x.Name == "SSDs").Id },
                new Product { Name = "Sandisk X110 mSATA 256GB", CategoryId = context.Categories.Single(x => x.Name == "SSDs").Id }
                );
            context.Products.AddOrUpdate(x => x.Name,
                new Product { Name = "Toshiba L200 1TB", CategoryId = context.Categories.Single(x => x.Name == "HDDs").Id },
                new Product { Name = "Western Digital Caviar Blue 1TB 3.5\" SATA иии", CategoryId = context.Categories.Single(x => x.Name == "HDDs").Id },
                new Product { Name = "Seagate Surveillance HDD 1TB", CategoryId = context.Categories.Single(x => x.Name == "HDDs").Id },
                new Product { Name = "Western Digital AV-GP 1TB SATA III", CategoryId = context.Categories.Single(x => x.Name == "HDDs").Id },
                new Product { Name = "Seagate Barracuda 2TB SATA HDD", CategoryId = context.Categories.Single(x => x.Name == "HDDs").Id },
                new Product { Name = "Western Digital Desktop Mainstream 2TB", CategoryId = context.Categories.Single(x => x.Name == "HDDs").Id },
                new Product { Name = "Western Digital Red 2TB SATA III", CategoryId = context.Categories.Single(x => x.Name == "HDDs").Id },
                new Product { Name = "Seagate Desktop HDD 2TB SATA", CategoryId = context.Categories.Single(x => x.Name == "HDDs").Id },
                new Product { Name = "Toshiba DT01ACA300 3TB", CategoryId = context.Categories.Single(x => x.Name == "HDDs").Id }
                );
            context.Products.AddOrUpdate(x => x.Name,
                new Product { Name = "Samsung STSHX-D201TDB 2TB", CategoryId = context.Categories.Single(x => x.Name == "External Hard Drives").Id },
                new Product { Name = "Western Digital Elements 1.5TB", CategoryId = context.Categories.Single(x => x.Name == "External Hard Drives").Id },
                new Product { Name = "Seagate M3 Portable 2000GB", CategoryId = context.Categories.Single(x => x.Name == "External Hard Drives").Id },
                new Product { Name = "Seagate Expansion Desktop 2TB", CategoryId = context.Categories.Single(x => x.Name == "External Hard Drives").Id },
                new Product { Name = "Samsung M3 Portable 2TB", CategoryId = context.Categories.Single(x => x.Name == "External Hard Drives").Id },
                new Product { Name = "Western Digital Elements 2TB", CategoryId = context.Categories.Single(x => x.Name == "External Hard Drives").Id },
                new Product { Name = "Toshiba Canvio Connect II 2TB", CategoryId = context.Categories.Single(x => x.Name == "External Hard Drives").Id },
                new Product { Name = "Seagate Expansion Desktop 3TB", CategoryId = context.Categories.Single(x => x.Name == "External Hard Drives").Id },
                new Product { Name = "Western Digital My Book 3TB (WDBFJK0030HBK)", CategoryId = context.Categories.Single(x => x.Name == "External Hard Drives").Id }
                );
            context.Products.AddOrUpdate(x => x.Name,
                new Product { Name = "Manhattan Drive Enclosure 130103", CategoryId = context.Categories.Single(x => x.Name == "Hard Disk Frames & Enclosures").Id },
                new Product { Name = "StarTech SAT2510BU2", CategoryId = context.Categories.Single(x => x.Name == "Hard Disk Frames & Enclosures").Id },
                new Product { Name = "Manhattan 130042", CategoryId = context.Categories.Single(x => x.Name == "Hard Disk Frames & Enclosures").Id },
                new Product { Name = "StarTech SAT2510BU2E", CategoryId = context.Categories.Single(x => x.Name == "Hard Disk Frames & Enclosures").Id },
                new Product { Name = "StarTech S2510BMU33CB", CategoryId = context.Categories.Single(x => x.Name == "Hard Disk Frames & Enclosures").Id },
                new Product { Name = "StarTech S251BPU313", CategoryId = context.Categories.Single(x => x.Name == "Hard Disk Frames & Enclosures").Id },
                new Product { Name = "StarTech SAT2510U3S", CategoryId = context.Categories.Single(x => x.Name == "Hard Disk Frames & Enclosures").Id },
                new Product { Name = "Logilink UA0214", CategoryId = context.Categories.Single(x => x.Name == "Hard Disk Frames & Enclosures").Id },
                new Product { Name = "StarTech S252BU33R", CategoryId = context.Categories.Single(x => x.Name == "Hard Disk Frames & Enclosures").Id }
                );
            context.SaveChanges();
        }
    }
}
