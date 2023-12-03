# TP3
    Vous devez changer la chaine de connexion dans le fichier appsettings.json par ta propre chaine de connexion.

# TP2
    Vous devez changer la chaine de connexion dans le fichier appsettings.json par ta propre chaine de connexion.

# TP1
## Test des URL
	http://localhost:5044
	http://localhost:5044/Movie
	http://localhost:5044/Movie/index
	http://localhost:5044/Movie/Edit/id ex: http://localhost:5044/Movie/Edit/1
	http://localhost:5044/Movie/year/month ex: http://localhost:5044/Movie/released/2023/11
	http://localhost:5044/Movie/clients
	http://localhost:5044/Movie/clients/id ex: http://localhost:5044/Movie/clients/2


## Reponses
### 1. Modifiez le route pour inclure l'URL Movie/released/2020/03 pour une Action ByRelease ayant comme arguments (month, year)retournant juste un contenu.

Voir MovieController.cs

### 2. Executez. Que remarquez vous? Quel changement faire pour que le systeme de routage prend en charge cet route? Expliquez les differentes eventualites rencontrees.

L'url Movie/released/2020/03 ne fonctionne pas car le systeme de routage ne prend pas en charge cette route. Il faut configurer la route de maniere a ce que le systeme de routage puisse la prendre en charge. 

On peut:
	1- Ajouter une nouvelle route dans le fichier Program.cs ( c'est ce que j'ai fait)
	2- Ajouter un attribut Route sur la methode ByRelease du controlleur MovieController.cs
	3- Ajouter une classe qui implemente l'interface IRouter


### 3.Presentez avec des exemples les differents systemes de routage si vous travaillez avec le framework de developpement web ASP.Net.

A. Convention-based routing: 
	- C'est le systeme de routage par defaut
	- Il est base sur le nom du controlleur et le nom de l'action
	- Il est defini dans le fichier Program.cs

B. Attribute routing:
	- Il est base sur les attributs
	- Il est defini au niveau du controlleur

C. Custom Routing:
	- Il est base sur une classe qui implemente l'interface IRouter
	- Il est defini dans le fichier Program.cs

### 4. On veut a present passer deux modeles a la vue (Movie et Customer)
- Ajouter une classe Customer (Id, Name)
- On veut passer a la vue un film et une Liste de Clients (Penser a ajouter ViewModel)
- Lister (statique) les enregistrements au niveau du controlleur (retourner le VM)
- Changer le modele assigne a la vue
- Recuperer les details du client par son Id.
