# Boutique Diayma

# Tâche 2 : Projets de la solution
La solution contient un seul projet : **Diayma**


# Tâche 3 : Version SDK .NET utilisée
En analysant la balise <TargetFramework> dans le fichier Diayma.csproj:

Voici la section qui nous interesse 
  #  <PropertyGroup>
  #   <TargetFramework>netcoreapp2.0</TargetFramework>
  #  </PropertyGroup>

Et si on se base sur la section la version du SDK .NET utilisée par le projet est **.NET Core 2.0.**


# Tâche 4 : Installez le SDK 
J'ai installer le SDK  en utilisant ce lien :
[https://dotnet.microsoft.com/en-us/download]


# Tâche 5 : Créez votre propre dépôt GitHub pour y stocker le code 
J'ai cree mon propre depot accessible a ce lien:
[https://github.com/Aichasagne/DiaymaBoutique.git]


# Tâche 6 : Explorez l’application. Signalez 2 bugs trouvés ? 
Apres exploration voici les bugs que j'ai trouve

**Bug 1 :** 
Gestion incorrecte de la suppression des articles dans le Panier. En mode panier, cliquer sur l'option de suppression d'un article retire toute la quantite ajouter au panier. 

**Bug 2 :** 
Lors de la finalisation de la commande, l'application affiche un message de "Démo est terminée". Ceci est la preuve que le fichier Startup.cs (ligne 20) est configuré pour injecter un service fictif (Mock Repository) à la place du véritable service de persistance, rendant le système incapable d'enregistrer réellement les commandes.


