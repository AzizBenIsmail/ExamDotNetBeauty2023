# ExamDotNetBeauty2023
# class
    public enum PlaneType
    {
        BOING=1,AIRBUS=2
    }
						---------
	public class Flight
    { prop ...
	public string Nom { get; set; }
	}
# ANNOTATIONS
### Obligatoire: 
	[Required]
### obligatoire avec message d'erreur:  
	[Required(ErrorMessage ="Champs obligatoire")]

## base_de_donné

### Ne voulons pas créer de colonnes correspondantes dans la base de données :
	[NotMapped]
### Nom d'une table dans une table db : 
	[Table("MyFlight")]
### Nom d'une colonne dans une table db : 
	[Column("Name")]
### Type de données d'une colonne :
	[Column("DoB", TypeName="DateTime2")]

## Clé

### clé primaire: 
	[Key]
### commençant par l'index zéro : 
	[Column(Order=1)]
### cle etrangere : 
	[ForeignKey(“StandardId”)]

## un champ de 7 caractères

	[MinLength(7, ErrorMessage = "MinLength 7")]
	[MaxLength(7, ErrorMessage = "MaxLength 7")]
### ou 
	[StringLength(7, MinimumLength = 7, ErrorMessage = "il faut etre 7 characters .. ... ...")]
	[StringLength(25, MinimumLength = 3, ErrorMessage = "First entre 3 characters et 25 characters .")]
### ou
	[Range(0,int.MaxValue,ErrorMessage ="entier positive")]
	[Range(1,120, ErrorMessage="Age must be between 1-120 in years.")]

### Positif ne depasse pas 24 :
	[Range(0,24)]

### Nombre positif/negatif: 
	[Range(0, int.MaxValue)] 
### ou
	[Range(0, int.MinValue)]

## DATATYPE ATTRIBUTE

### date valide: 
	[DataType(DataType.Date)]

### multiligne: 
	[DataType(DataType.MultilineText)]

### Type monnaie: 
	[DataType(DataType.Currency)]

### CreditCard : 
	[DataType(DataType.Currency)]

### DateTime : 
	[DataType(DataType.DateTime)]

### EmailAddress : 
	[DataType(DataType.EmailAddress,ErrorMessage ="aaa")]

### ImageUrl : 
	[DataType(DataType.ImageUrl)]

### Password : 
	[DataType(DataType.Password)]

### PhoneNumber : 
	[DataType(DataType.PhoneNumber)]

### PostalCode : 
	[DataType(DataType.PostalCode)]

### Text : 
	[DataType(DataType.Text)]

### Time : 
	[DataType(DataType.Time)]

## COMPARE ATTRIBUTE

	[Compare("Email", ErrorMessage= "Email Not Matched")]

## longueur maximale 

### longueur maximale de la valeur de données autorisée pour une propriété : 
	[MaxLength(50)]

### le nombre maximum de caractères autorisés : 
	[StringLength(50)]

### Phone EmailAddress

        [Phone(ErrorMessage ="phone number")]
        [EmailAddress(ErrorMessage = "une address email invalid .")]

## colonne

### affichage du nom de la colonne dans l’ interface utilisateur :
					[Display(Name = “Student Email“)]
							public string Email { get; set;}
        [Display(Name = "Date of Birth")]

# heritgae
    public class Staff :Passenger
    
# relation
### Many to Many *->*:
	public virtual ICollection<Postulant> Postulants { get; set; }
### One to Many (Many to One) * -> 1 :  
	public virtual Entreprise Entreprise { get; set; }

		[ForeignKey("PlaneId")] 
	ou bien
        	public virtual Plane? MyPlane { get; set; }

        [ForeignKey("MyPlane")]
        public int? PlaneId { get; set; } //prop
        //tp5 Q6
        //public IList<Passenger> passengers { get; set; }
        public virtual IList<Reservation> Reservations { get; set; }
# Config
### changer le nom de la table : 
	builder.ToTable("MyFlight");
	
### changer le nom de la attribue : 
		builder.Property(p => p.Capacity).HasColumnName("PlaneCapacity");
            builder.HasKey(p => p.PlaneId);
	
### declarer une relation
            builder
                .HasOne(f => f.MyPlane) // ta3 class 1 thot feha one or many w attribue 1
                .WithMany(p => p.Flights) // ta3 class 2 thot feha one or many w attribue 2
                .HasForeignKey(f => f.PlaneId)
                .OnDelete(DeleteBehavior.SetNull);
				OR
	un simple  [ForeignKey(“PlaneId”)] fou9 declamation du var plane
			
### cas Many to Many mnghir table fil west 
            //builder
            //    .HasMany(f => f.passengers)
            //    .WithMany(p => p.Flights)
            //    .UsingEntity(ass => ass.ToTable("FP")); 

### cas Many to Many w fama table ili fil west
tasna3ha wahdha l classe ili fil west mba3ed tzidha 
	
			----------------
        public virtual Passenger MyPassenger { get; set; }
        public string PassengerId { get; set; }
        public virtual Flight MyFlight { get; set; }
        public int FlightId { get; set; }
			-----------------
            builder.HasOne(r => r.MyPassenger)
                .WithMany(p => p.Reservations)
                .HasForeignKey(r=>r.PassengerId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(r=>r.MyFlight)
                .WithMany(f=>f.Reservations)
                .HasForeignKey(r=>r.FlightId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasKey(r => new { r.FlightId, r.PassengerId });

$$$ => tansech t3aytelha fil OnModelCreating

### Question mchag3eb TPH (Table Par Hiérarchie).
Configurer l’héritage schématisé dans le diagramme de classe de façon à ce que les
entités seront mappées à
IsTraveller : 
=> fil FlightConfig
### Exp 1	
	
	modelBuilder.Entiy<Membre>()
	.HasDiscriminator<string>("Type")
	.HasValue<Entraineur>("e")
	.HasValue<Joueur>("j")
	.HasValue<Membre>("m");
### Exp 2
	
            builder.HasDiscriminator<int>("isTraveler")
                .HasValue<Passenger>(0)
                .HasValue<Traveller>(1)
                .HasValue<Staff>(2);
### Question mchag3eb TPT (Table Par Table)
Configurer l'héritage schéématisé dans le diagramme de classe de façonn à ce que les entités 
seront mappées sur 3 tabllee :
=> fil AMContext
### exp 1
	
	modelBuilder.Entity<Biological>().ToTable("Biologicals");
	modelBuilder.Entity<Chemical>().ToTable("Chemicals");
### exp 2
            modelBuilder.Entity<Staff>().ToTable("Staffs");
            modelBuilder.Entity<Traveller>().ToTable("Travellers");
## LazyLoading
tzidha fil OnConfiguring fil AMContext7
	
	optionsBuilder.UseLazyLoadingProxies(); 
ay propriétés de navigation tzidha 9dem public virtual (ay haja de type classe o5ra) 
## AMContexe
	
	 public class AMContext : DbContext //herite de DbContext
 	   {
  	      public DbSet<Flight> Flights { get; set; } // pour chaque classe

### parametrer l'acces a la base de donne
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb; 
                    Initial Catalog = Airport;  
                    Integrated Security = true");
            //Tp5 Q13
            optionsBuilder.UseLazyLoadingProxies(); // LazyLoading
         
        }
### pour appliquer le modification du Flightconfig
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfiguration(new ReservationConfig());

        }
### si fama tabdila ala nes lkol
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>()
                .HaveColumnType("date");
        }
    }
# constructeur

        public Plane(PlaneType pt, int capacity, DateTime date)
        {
            Capacity = capacity;// on peut utiliser  this.Capacity = capacity; ou sans this (pour distinguer les noms)
            ManufactureDate = date;
            MyPlaneType = pt;
        }
# ToString
        public override string ToString()
        {
            return "Capacity:" + Capacity + ";"
                + "ManufactureDate:" + ManufactureDate + ";"
                + "PlaneId:" + PlaneId + ";"
                + "PlaneType:" + MyPlaneType;
        }

# Services
Services pour cree les fonction de modifercation Crud
on Va Cree IFlightService comme interface des fonction dans FlightService et herite IFlightService et dans FlightService on cree les fonction
	
	public class FlightService :Service<Flight>, IFlightService
	{}
        public IList<Flight> Flights { get; set; } //prop

        public IList<DateTime> GetFlightDates(string destination) // linqIntegre
        {
            //return (from f in Flights 
            //       where f.Destination == destination
            //       select f.FlightDate).ToList();
            return Flights.Where(f => f.Destination == destination) //Methoded'extention
                .Select(f => f.FlightDate).ToList();

        }
# Le langage LINQ
	
	var PersoQuery =
	from perso in personnes 
	where ( perso.Budget > 500)
	orderby perso.Nom ascending
	select new { Name = perso.Nom, Number = perso.Num};

## First(): 
Renvoie le premier élément d'une collection ou le premier élément qui
satisfait une condition.

## FirstOrDefault():
Renvoie le premier élément d'une collection ou le premier
élément qui satisfait une condition. Renvoie une valeur par défaut si l'index est
hors plage.

## Single(): 
Renvoie le seul élément d'une collection ou le seul élément qui satisfait à
une condition.

## SingleOrDefault(): 
Identique à Single, sauf qu'il renvoie une valeur par défaut
d'un type générique spécifié, au lieu de lever une exception

## Last(): 
Renvoie le dernier élément d'une collection ou le dernier élément qui
satisfait à une condition.

## LastOrDefault(): 
Renvoie le dernier élément d'une collection ou le dernier
élément qui satisfait à une condition. Renvoie une valeur par défaut si aucun
élément de ce type n'existe.

## Skip(): 

Pour indiquer le nombre d’ élément a ignorer de la sélection.

## Take(): 

Pour indiquer le nombre d’ élément a garder de la sélection.

## Average(): 

calcule la moyenne des éléments numériques de la collection.

## Sum() : 

calcule la somme des éléments numériques de la collection.

## Max(): 

renvoie le plus grand élément numérique d'une collection.

## Count: 

renvoie le nombre d'éléments de la collection ou le nombre d'éléments
qui ont satisfait à la condition donnée.

# Les méthodes anonymes
        public void ShowFlightDetails(Plane plane)
        {
            var result = from f in Flights
                         where f.MyPlane.PlaneId == plane.PlaneId
                         select new { f.Destination, f.FlightDate }; //type anonyme
            foreach (var item in result)
            {
                Console.WriteLine("destination : " + item.Destination +
                    "date :" + item.FlightDate);
            }
        }
## 
    internal class ReservationConfig : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasOne(r => r.MyPassenger)
                .WithMany(p => p.Reservations)
                .HasForeignKey(r=>r.PassengerId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(r=>r.MyFlight)
                .WithMany(f=>f.Reservations)
                .HasForeignKey(r=>r.FlightId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasKey(r => new { r.FlightId, r.PassengerId });
        }

    }
# Migration de base de donne
	Add-Migration
	Update-Database 
# Configuration
	
    	Public class PlaneConfig : IEntityTypeConfiguration<Plane>
    	{
	        public void Configure(EntityTypeBuilder<Plane> builder)
	        {
	            builder.ToTable("MyPlanes"); //modifcation du nom
	            builder.Property(p => p.Capacity).HasColumnName("PlaneCapacity");
	            builder.HasKey(p=>p.PlaneId); // fixsage du cle primere
        	}
	    }
# Relation
            //builder
            //    .HasMany(f => f.passengers)
            //    .WithMany(p => p.Flights)
            //    .UsingEntity(ass => ass.ToTable("FP"));   

            builder
                .HasOne(f => f.MyPlane)
                .WithMany(p => p.Flights)
                .HasForeignKey(f => f.PlaneId)
                .OnDelete(DeleteBehavior.SetNull);
