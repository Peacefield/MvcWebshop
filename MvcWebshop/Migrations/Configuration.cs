namespace MvcWebshop.Migrations
{
    using MvcWebshop.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcWebshop.Models.WebshopDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MvcWebshop.Models.WebshopDBContext context)
        {
            LeegDatabase(context);

            //  This method will be called after migrating to the latest version.

            // add-migration
            // update-database

            #region categorieen
            Categorie catPan = new Categorie
            {
                plaatje = "https://data.archive.horse/4ch/mlp/image/1430/94/1430947175071.jpg",
                naam = "Pannen",
                omschrijving = "Pannen"
            };

            Categorie catBestek = new Categorie
            {
                plaatje = "http://www.omafia.nl/bestek/omafia.php?thumb=bestek/bestek013.jpg",
                naam = "Bestek",
                omschrijving = "Bestek"
            };

            Categorie catKoffie = new Categorie
            {
                plaatje = "http://img.prijsvergelijk.nl/images/koffie-apparaten/delonghi-en720m.jpg",
                naam = "Koffie",
                omschrijving = "Koffie artikelen"
            };
            Categorie catThee = new Categorie
            {
                plaatje = "http://www.o-kado.nl/productimages/oilily-theepot-4787351.jpg",
                naam = "Thee",
                omschrijving = "Thee artikelen"
            };

            Categorie catKeuken = new Categorie
            {
                plaatje = "http://www.interkeuken.nl/slaapkamerconcurrent/upload/8734IMG_3135.JPG",
                naam = "Keuken",
                omschrijving = "Keuken artikelen"
            };
            #endregion

            #region producten
            Product pan = new Product
            {
                plaatje = "https://data.archive.horse/4ch/mlp/image/1430/94/1430947175071.jpg",
                naam = "Frying Pan",
                omschrijving = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. "
                + "Vivamus accumsan, turpis vel lacinia interdum, elit ligula finibus erat, "
                + "facilisis iaculis est mauris id mauris. Aliquam ullamcorper neque id "
                + "est tempor, non pharetra erat dapibus. Quisque vitae accumsan augue. "
                + "Nullam ultrices in dolor vel vulputate. Quisque aliquam nibh sit amet "
                + "nulla gravida, sed gravida libero pretium. Morbi facilisis ipsum ac dolor "
                + "luctus, vel accumsan mi hendrerit. Proin semper gravida mattis. Cras sodales "
                + "ex elit, id accumsan quam semper faucibus. Vestibulum nec hendrerit nibh, dictum lobortis sapien.",
                prijs = 5.99,
                categories = new System.Collections.Generic.List<Categorie>()
                {
                    catPan,
                    catKeuken
                }
            };

            Product bestek = new Product
            {
                plaatje = "http://www.omafia.nl/bestek/omafia.php?thumb=bestek/bestek013.jpg",
                naam = "Bestekset",
                omschrijving = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. "
                + "Donec et tortor laoreet, placerat est in, commodo ante. Fusce ut sem "
                + "eu purus scelerisque lacinia in eu turpis. Mauris efficitur at libero "
                + "eu finibus. Sed at dui sed urna ornare porttitor sit amet sit amet nisi. "
                + "Cum sociis natoque penatibus et magnis dis parturient montes, nascetur "
                + "ridiculus mus. Sed sit amet consectetur purus, vel varius dolor. Curabitur "
                + "porta metus ornare nisl pellentesque iaculis. Ut sed ultricies dui. "
                + "Ut imperdiet eros non quam hendrerit, in sollicitudin nulla aliquet. In commodo imperdiet enim vel rutrum.",
                prijs = 5.99,
                categories = new System.Collections.Generic.List<Categorie>()
                {
                    catBestek,
                    catKeuken
                }
            };

            Product koffie = new Product
            {
                plaatje = "http://img.prijsvergelijk.nl/images/koffie-apparaten/delonghi-en720m.jpg",
                naam = "Koffiezetapparaat De'longhi",
                omschrijving = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. "
                + "Proin sit amet lectus ipsum. Vivamus ac odio ligula. Suspendisse massa "
                + "leo, suscipit non commodo dapibus, tempus id velit. Duis convallis elit "
                + "non nunc mollis, non lacinia odio pharetra. Duis feugiat placerat mi quis "
                + "fringilla. Nunc gravida ex vitae mauris accumsan, a convallis tortor "
                + "vestibulum. Integer mattis eu purus quis suscipit. Suspendisse hendrerit "
                + "id neque sed lacinia. Quisque accumsan, purus sit amet interdum finibus, "
                + "purus ipsum volutpat dolor, id facilisis eros ex eu purus. In et massa lacus. "
                + "Proin sed massa purus. In erat magna, commodo aliquam diam sed, tempor suscipit dolor.",
                prijs = 5.99,
                categories = new System.Collections.Generic.List<Categorie>()
                {
                    catKoffie,
                    catKeuken
                }
            };
            Product thee = new Product
            {
                plaatje = "http://www.o-kado.nl/productimages/oilily-theepot-4787351.jpg",
                naam = "Oilily Theepot",
                omschrijving = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. "
                + "Nunc sodales, neque quis tempus ultrices, leo eros imperdiet risus, sit "
                + "amet ultricies ligula mi sit amet tellus. Aenean dictum arcu et placerat "
                + "consectetur. Praesent massa nisi, accumsan at est sed, aliquam egestas mi. "
                + "Praesent vel neque non massa tincidunt ultricies. Sed cursus aliquet posuere. "
                + "Sed sit amet metus eget orci aliquet faucibus. Proin sagittis risus tristique "
                + "cursus porttitor. Vestibulum quam elit, suscipit et velit in, varius tincidunt "
                + "diam. Suspendisse laoreet, ante sed vulputate imperdiet, sapien sapien congue enim, "
                + "accumsan sagittis risus odio eget augue. Vestibulum iaculis sed mauris eu facilisis. "
                + "Pellentesque habitant morbi tristique senectus et netus et malesuada fames "
                + "ac turpis egestas. Praesent a hendrerit purus.",
                prijs = 5.99,
                categories = new System.Collections.Generic.List<Categorie>()
                {
                    catThee,
                    catKeuken
                }
            };
            Product keuken = new Product
            {
                plaatje = "http://www.interkeuken.nl/slaapkamerconcurrent/upload/8734IMG_3135.JPG",
                naam = "Keuken",
                omschrijving = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. "
                + "Vestibulum facilisis nunc a velit maximus, quis ornare metus fermentum. "
                + "Mauris et odio posuere ipsum pretium tempus in et neque. Sed ligula mi, "
                + "rutrum fermentum diam et, finibus lobortis ligula. Phasellus ut lobortis "
                + "diam, ac commodo libero. Morbi pharetra dictum odio ac laoreet. Maecenas "
                + "elementum luctus odio, sed auctor ligula laoreet ut. Ut eget lectus ligula. "
                + "Phasellus elementum quis enim eu cursus. Cras mollis aliquet augue nec luctus.",
                prijs = 15.99,
                categories = new System.Collections.Generic.List<Categorie>()
                {
                    catKeuken
                }
            };
            #endregion

            #region Aanbiedingen

            DateTime startDatum = DateTime.Now;
            DateTime eindDatum = startDatum.AddMonths(1);
            Aanbieding aanbiedingPan = new Aanbieding
            {
                aanbiedingsprijs = 3.99,
                product = pan,
                datumVan = startDatum,
                datumTot = eindDatum,
                reclametekst = "Begin nu met bakken met een nieuwe pan!"
            };

            Aanbieding aanbiedingBestek = new Aanbieding
            {
                aanbiedingsprijs = 3.69,
                product = bestek,
                datumVan = startDatum,
                datumTot = eindDatum,
                reclametekst = "Weg met dat oude bestek, verwen jzelf met dit prachtige bestek! "
            };

            Aanbieding aanbiedingThee = new Aanbieding
            {
                aanbiedingsprijs = 3.49,
                product = thee,
                datumVan = startDatum,
                datumTot = eindDatum,
                reclametekst = "Drink thee in stijl!"
            };
            #endregion

            context.Producten.Add(pan);
            context.Producten.Add(bestek);
            context.Producten.Add(koffie);
            context.Producten.Add(thee);
            context.Producten.Add(keuken);

            context.Categorieen.Add(catBestek);
            context.Categorieen.Add(catKeuken);
            context.Categorieen.Add(catKoffie);
            context.Categorieen.Add(catThee);
            context.Categorieen.Add(catPan);

            context.Aanbiedingen.Add(aanbiedingBestek);
            context.Aanbiedingen.Add(aanbiedingPan);
            context.Aanbiedingen.Add(aanbiedingThee);
        }

        public void LeegDatabase(MvcWebshop.Models.WebshopDBContext context)
        {
            foreach (Categorie obj in context.Categorieen)
                context.Categorieen.Remove(obj);

            foreach (Product obj in context.Producten)
                context.Producten.Remove(obj);

            foreach (Aanbieding obj in context.Aanbiedingen)
                context.Aanbiedingen.Remove(obj);

            foreach (Klant obj in context.Klanten)
                context.Klanten.Remove(obj);

            foreach (Order obj in context.Orders)
                context.Orders.Remove(obj);

            foreach (Orderregel obj in context.Orderregels)
                context.Orderregels.Remove(obj);

            context.SaveChanges();
        }
    }
}
