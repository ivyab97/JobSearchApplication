using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Infraestructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Category { get; set; }
        public DbSet<ApplicationStatusType> ApplicationStatusType { get; set; }
        public DbSet<Offer> Offer { get; set; }
        public DbSet<OfferCategory> OfferCategory { get; set; }
        public DbSet<Application> Application { get; set; }
        public DbSet<Experience> Experience { get; set; }
        public DbSet<StudyLevel> StudyLevel { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Get path for precharge  data
            string currentDirectory = Directory.GetCurrentDirectory();
            currentDirectory = currentDirectory.Substring(0, currentDirectory.Length - 16);

            string JsonFileOnePath = Path.Combine(currentDirectory, "Infraestructure", "Persistence", "CategoryData.json");
            var categoryJson = File.ReadAllText(JsonFileOnePath);
            var categories = JsonConvert.DeserializeObject<List<Category>>(categoryJson);

            string JsonFileTwoPath = Path.Combine(currentDirectory, "Infraestructure", "Persistence", "ApplicationStatusTypeData.json");
            var statusTypesJson = File.ReadAllText(JsonFileTwoPath);
            var StutusTypes = JsonConvert.DeserializeObject<List<ApplicationStatusType>>(statusTypesJson);

            string JsonFileThreePath = Path.Combine(currentDirectory, "Infraestructure", "Persistence", "OfferData.json");
            var offerJson = File.ReadAllText(JsonFileThreePath);
            var offers = JsonConvert.DeserializeObject<List<Offer>>(offerJson);

            string JsonFileFourPath = Path.Combine(currentDirectory, "Infraestructure", "Persistence", "OfferCategoryData.json");
            var offerCategoryJson = File.ReadAllText(JsonFileFourPath);
            var offerCategories = JsonConvert.DeserializeObject<List<OfferCategory>>(offerCategoryJson);

            string JsonFileFivePath = Path.Combine(currentDirectory, "Infraestructure", "Persistence", "ExperienceData.json");
            var experienceJson = File.ReadAllText(JsonFileFivePath);
            var experiences = JsonConvert.DeserializeObject<List<Experience>>(experienceJson);

            string JsonFileSixPath = Path.Combine(currentDirectory, "Infraestructure", "Persistence", "StudyLevelData.json");
            var studyLevelJson = File.ReadAllText(JsonFileSixPath);
            var StudyLevels = JsonConvert.DeserializeObject<List<StudyLevel>>(studyLevelJson);

            modelBuilder.Entity<Offer>(entity =>
            {
                entity.ToTable("Offer");
                entity.HasKey(oi => oi.OfferId);
                entity.Property(oi => oi.OfferId)
                      .IsRequired();
                entity.Property(ei => ei.CompanyId)
                      .IsRequired();
                entity.Property(t => t.Title)
                      .IsRequired()
                      .HasMaxLength(50);
                entity.Property(d => d.Description)
                     .IsRequired()
                     .HasMaxLength(1500);
                entity.Property(s => s.Salary);
                entity.Property(ae => ae.ExperienceId);
                entity.Property(p => p.ProvinceId)
                      .IsRequired();
                entity.Property(c => c.CityId)
                      .IsRequired();
                entity.Property(ne => ne.StudyLevelId)
                      .IsRequired();
                entity.Property(f => f.Date)
                      .IsRequired();
                entity.Property(f => f.Status)
                      .IsRequired();


                entity.HasMany<OfferCategory>(oc => oc.OfferCategory)
                      .WithOne(o => o.Offer)
                      .HasForeignKey(oi => oi.OfferId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany<Application>(p => p.Application)
                      .WithOne(o => o.Offer)
                      .HasForeignKey(oi => oi.OfferId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne<Experience>(e => e.Experience)
                      .WithMany(o => o.Offer)
                      .HasForeignKey(ei => ei.ExperienceId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne<StudyLevel>(ne => ne.StudyLevel)
                      .WithMany(o => o.Offer)
                      .HasForeignKey(nei => nei.StudyLevelId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasData(offers);
            });


            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");
                entity.HasKey(ci => ci.CategoryId);
                entity.Property(ci => ci.CategoryId)
                      .ValueGeneratedOnAdd()
                      .IsRequired();
                entity.Property(d => d.Name)
                     .IsRequired()
                     .HasMaxLength(50);


                entity.HasMany<OfferCategory>(oc => oc.OfferCategory)
                      .WithOne(c => c.Category)
                      .HasForeignKey(ci => ci.CategoryId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasData(categories);
            });


            modelBuilder.Entity<OfferCategory>(entity =>
            {
                entity.ToTable("OfferCategory");
                entity.HasKey(oci => oci.OfferCategoryId);
                entity.Property(oci => oci.OfferCategoryId)
                      .ValueGeneratedOnAdd()
                      .IsRequired();
                entity.Property(oi => oi.OfferId)
                      .IsRequired();
                entity.Property(ci => ci.CategoryId)
                     .IsRequired();
                entity.Property(f => f.Status)
                      .IsRequired();

                entity.HasOne<Offer>(o => o.Offer)
                      .WithMany(oc => oc.OfferCategory)
                      .HasForeignKey(oi => oi.OfferId);

                entity.HasOne<Category>(c => c.Category)
                      .WithMany(oc => oc.OfferCategory)
                      .HasForeignKey(ci => ci.CategoryId);

                entity.HasData(offerCategories);
            });


            modelBuilder.Entity<Application>(entity =>
            {
                entity.ToTable("Application");
                entity.HasKey(pi => pi.ApplicationId);
                entity.Property(pi => pi.ApplicationId)
                      .ValueGeneratedOnAdd()
                      .IsRequired();
                entity.Property(ei => ei.ApplicationStatusTypeId)
                      .IsRequired();
                entity.Property(ai => ai.ApplicantId)
                      .IsRequired();
                entity.Property(oi => oi.OfferId)
                      .IsRequired();
                entity.Property(f => f.Date)
                     .IsRequired();
                entity.Property(f => f.Status)
                      .IsRequired();

                entity.HasOne<Offer>(o => o.Offer)
                      .WithMany(p => p.Application)
                      .HasForeignKey(oi => oi.OfferId);

                entity.HasOne<ApplicationStatusType>(tep => tep.ApplicationStatusType)
                      .WithOne(p => p.Application)
                      .HasForeignKey<Application>(ei => ei.ApplicationStatusTypeId);
            });

            modelBuilder.Entity<ApplicationStatusType>(entity =>
            {
                entity.ToTable("ApplicationStatusType");
                entity.HasKey(ei => ei.ApplicationStatusTypeId);
                entity.Property(ei => ei.ApplicationStatusTypeId)
                      .ValueGeneratedOnAdd()
                      .IsRequired();
                entity.Property(d => d.Name)
                     .IsRequired()
                     .HasMaxLength(50);

                entity.HasData(StutusTypes);
            });

            modelBuilder.Entity<Experience>(entity =>
            {
                entity.ToTable("Experience");
                entity.HasKey(ei => ei.ExperienceId);
                entity.Property(ei => ei.ExperienceId)
                      .ValueGeneratedOnAdd()
                      .IsRequired();
                entity.Property(d => d.Name)
                     .IsRequired()
                     .HasMaxLength(50);

                entity.HasMany<Offer>(oc => oc.Offer)
                      .WithOne(c => c.Experience)
                      .HasForeignKey(ci => ci.ExperienceId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasData(experiences);
            });

            modelBuilder.Entity<StudyLevel>(entity =>
            {
                entity.ToTable("StudyLevel");
                entity.HasKey(nei => nei.StudyLevelId);
                entity.Property(nei => nei.StudyLevelId)
                      .ValueGeneratedOnAdd()
                      .IsRequired();
                entity.Property(d => d.Name)
                     .IsRequired()
                     .HasMaxLength(50);

                entity.HasMany<Offer>(oc => oc.Offer)
                      .WithOne(c => c.StudyLevel)
                      .HasForeignKey(ci => ci.StudyLevelId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasData(StudyLevels);
            });
        }

    }
}
