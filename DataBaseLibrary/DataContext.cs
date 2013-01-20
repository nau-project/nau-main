#region Usages

using System.Configuration;
using System.Data.Entity;
using DataBaseLibrary.Entities;

#endregion

namespace DataBaseLibrary
{
    /// <summary>
    ///   Data context.
    /// </summary>
    public class DataContext : DbContext
    {
        #region Constructors

        /// <summary>
        ///   Creates a new <see cref = "DataContext" /> using the provided connection string.
        /// </summary>
        public DataContext() : base(_connectionString)
        {}

        #endregion

        #region Properties

        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        /// <summary>
        ///   Gets or sets <see cref = "DbSet" /> for db entities.
        /// </summary>
        public DbSet<Group> Groups { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Member> Members { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }
        #endregion

        #region Methods
        /// <inheritdoc />
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>().HasMany(gr => gr.Students).WithOptional(st => st.Group).WillCascadeOnDelete();
            modelBuilder.Entity<Schedule>().HasMany(sc => sc.Items).WithOptional().WillCascadeOnDelete();
            /*modelBuilder.Entity<Venue>().HasMany(venue => venue.ResourceGroups).WithOptional(group => group.Venue).WillCascadeOnDelete();
            modelBuilder.Entity<Venue>().HasMany(venue => venue.Resources).WithOptional(resource => resource.Venue).WillCascadeOnDelete();
            modelBuilder.Entity<Venue>().HasMany(venue => venue.BookingTemplates).WithOptional(template => template.Venue).WillCascadeOnDelete();
            modelBuilder.Entity<Venue>().HasRequired(venue => venue.AdditionalInfo).WithRequiredPrincipal().WillCascadeOnDelete();
            modelBuilder.Entity<VenueType>().HasMany(venueType => venueType.Venues).WithRequired(venue => venue.VenueType).WillCascadeOnDelete();
            
            modelBuilder.Entity<Rule>().HasMany(rule => rule.RuleTimeSegments).WithOptional(segment => segment.Rule).WillCascadeOnDelete();
            modelBuilder.Entity<Resource>().HasMany(resource => resource.Bookings).WithOptional(booking => booking.Resource).WillCascadeOnDelete();*/
        }

        #endregion
    }
}