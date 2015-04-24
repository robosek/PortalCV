---------------BAZA DANYCH-----------------------------------------
Tabele odpowiedzialne za przetrzymywanie danych z CV:

1. Education
2. Experience
3. Hobby
4. Language
5. Profession
6. Skill
7. Certificate
8. CV (Główna właściwość HasCV, tabela przeznaczona do sprawdzania czy użytkownik ma już swoje CV, żeby nie mógł utworzyć drugiego.)
9.CVModel(Listy właściwości wymienionych wyżej, przeznaczona do wysyłania danych z widoku generowania CV do odpowiedniego kontrolera )




Dane o użytkowniku:

1.UserViewModel


Kontekt umożliwiający łączenie z tymi tabelami:
EntityDbContext


-----------------Helpery-----------------------------------------

W folderze App_Code znajdują się kody gotowych helperów do tworzenia boostrapowych kontrolek:

Html.Panel(/**/); - tworzy bootstrapowy panel 
ButtonHelper.Button(/**/) - tworzy bootstrapowy button
Html.AlertHelper(/**/); - tworzy bootstrapowy alert

----------------Kontrolery----------------
UserController - odpowiada za operacje wykonywane na danych użytkownika 
SearchController - Kontroler odpowiedzialny za wyszukiwarkę w navBarze
CVController - Wszystkie operacje związane z tworzeniem usuwaniem CV oraz generwaniem widoków częściowych
AccountController - podstawowe operacje na kontach i dodatkowo operacje dla panelu administratora