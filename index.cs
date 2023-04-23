class Article {
    public int Reference { get; set; }
    public string Nom { get; set; }
    public decimal PrixVente { get; set; }
    public int QuantiteStock { get; set; }

    public Article(int reference, string nom, decimal prixVente, int quantiteStock) {
        this.Reference = reference;
        this.Nom = nom;
        this.PrixVente = prixVente;
        this.QuantiteStock = quantiteStock;
    }

    public override string ToString() {
        return string.Format("Référence : {0}\nNom : {1}\nPrix de vente : {2:C}\nQuantité en stock : {3}", Reference, Nom, PrixVente, QuantiteStock);
    }
}

using System;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        List<Article> stock = new List<Article>();

        while (true) {
            Console.WriteLine("Menu");
            Console.WriteLine("1. Afficher le stock");
            Console.WriteLine("2. Rechercher un article par référence");
            Console.WriteLine("3. Ajouter un article au stock");
            Console.WriteLine("4. Supprimer un article par référence");
            Console.WriteLine("5. Quitter");

            int choix;
            if (!int.TryParse(Console.ReadLine(), out choix)) {
                Console.WriteLine("Choix invalide.");
                continue;
            }

            switch (choix) {
                case 1:
                    AfficherStock(stock);
                    break;
                case 2:
                    RechercherArticle(stock);
                    break;
                case 3:
                    AjouterArticle(stock);
                    break;
                case 4:
                    SupprimerArticle(stock);
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Choix invalide.");
                    break;
            }
        }
    }

    static void AfficherStock(List<Article> stock) {
        Console.WriteLine("Stock :");
        foreach (Article article in stock) {
            Console.WriteLine(article.ToString());
        }
    }

    static void RechercherArticle(List<Article> stock) {
        Console.WriteLine("Référence de l'article à rechercher :");
        int reference;
        if (!int.TryParse(Console.ReadLine(), out reference)) {
            Console.WriteLine("Référence invalide.");
            return;
        }

        Article article = stock.Find(x => x.Reference == reference);
        if (article != null) {
            Console.WriteLine(article.ToString());
        } else {
            Console.WriteLine("Article non trouvé.");
        }
    }

    static void AjouterArticle(List<Article> stock) {
        Console.WriteLine("Référence :");
        int reference;
        if (!int.TryParse(Console.ReadLine(), out reference)) {
            Console.WriteLine("Référence invalide.");
            return;
        }

        Article article = stock.Find(x => x.Reference == reference);
        if (article != null) {
            Console.WriteLine("Article avec la même référence déjà existant.");
            return;
        }

        Console.WriteLine("Nom :");
        string nom = Console.ReadLine();

        Console.WriteLine("Prix de vente :");
        decimal prixVente;
        if (!decimal.TryParse(Console.ReadLine(), out prixVente)) {
            Console.WriteLine("Prix de vente invalide.");
            return;
        }

        Console.WriteLine("Quantité en stock :");
        int quantiteStock;
        if (!int.TryParse(Console.ReadLine(), out quantiteStock)) {
            Console.WriteLine("Quantité invalide.");
            return;
        }

        Article nouvelArticle = new Article(reference, nom, prixVente, quantiteStock);
        stock.Add(nouvelArticle);
        Console.WriteLine("Article ajouté avec succès.");
    }

    static void SupprimerArticle(List<Article> stock) {
        Console.WriteLine("Référence de l'article à supprimer :");
        int reference;
        if (!int.TryParse(Console.ReadLine(), out reference)) {
            Console.WriteLine("Référence invalide.");
            return;
        }

        Article article = stock.Find(x => x.Reference == reference);
        if (article != null) {
            stock.Remove(article);
            Console.WriteLine("Article supprimé avec succès.");
        } else {
            Console.WriteLine("Article non trouvé.");
        }
    }

    static void RechercherArticleParPrix(List<Article> stock) {
        Console.WriteLine("Intervalle de prix de vente (séparé par un espace) :");
        string input = Console.ReadLine();
        string[] intervalle = input.Split();

        if (intervalle.Length != 2 || !decimal.TryParse(intervalle[0], out decimal prixMin) || !decimal.TryParse(intervalle[1], out decimal prixMax)) {
            Console.WriteLine("Intervalle invalide.");
            return;
        }

        List<Article> articlesTrouves = stock.FindAll(x => x.PrixVente >= prixMin && x.PrixVente <= prixMax);
        if (articlesTrouves.Count == 0) {
            Console.WriteLine("Aucun article trouvé.");
            return;
        }

        Console.WriteLine("Articles trouvés :");
        foreach (Article article in articlesTrouves) {
            Console.WriteLine(article.ToString());
        }
}
    static void AfficherTousLesArticles(List<Article> stock) {
        if (stock.Count == 0) {
            Console.WriteLine("Le stock est vide.");
            return;
        }

        Console.WriteLine("Liste des articles :");
        foreach (Article article in stock) {
            Console.WriteLine(article.ToString());
        }
    }

    static void Quitter() {
        Environment.Exit(0);
}

}
