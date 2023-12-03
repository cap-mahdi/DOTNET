# TP2
    Assurez de modifier le fichier appsettings.json pour changer la chaine de connexion a votre base de donnees.


# TP1
## Test des URL
	https://localhost:7191/
	https://localhost:7191/Movie
	https://localhost:7191/Movie/index
	https://localhost:7191/Movie/Edit/id ex: https://localhost:7191/Movie/Edit/1
	https://localhost:7191/Movie/year/month ex: https://localhost:7191/Movie/released/2023/11
	https://localhost:7191/Movie/clients
	https://localhost:7191/Movie/clients/id ex: https://localhost:7191/Movie/clients/2


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