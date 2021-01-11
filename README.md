# GameHub Projekt
<br/>
<br/>

## Projekt leírás:
<br/>

Ezzel az ASP.Net projekttel egy olyan  **STEAM** -hez hasonló online közösségi platformot kívántam szimulálni amelyen képesek vagyunk felhasználói fiókokat regisztrálni és menedzselni.Az egyes fiókokhoz képesek vagyunk játékszoftereket hozzáadni és törölni , a játékokhoz pedig a felhasználó által megszerzett kitüntetéseket lehet feltűntetni.
Lehetőség van az egyes fiókokhoz tartozó játékokat és az azokhoz rendelt kitűntetések kilistázására , illetve megtehetjük, hogy az összeset lekérjük egyszerre.Ezen felül mindhárom modell adatait meg tudjuk változtatni.Végül implementálva lett néhány statisztikai lekérdezés ami már az adatbázisban szereplő adatok függvényében fut le.
<br/>
<br/>

## A projekthez használt nyelvek

- ASP.NET  (C#)
- HTML
- CSS
- JAVASCRIPT

## Rétegzés

A projekt egy rétegzett alkalmazás, ezek a rétegek :
1. Models
   - A projektben haszált modellek osztályait tartalmazza , ezek közül a 3 legfontosabb :
     - User 
     - Game
     - Achievement
2. Data
   - A projekt adatbázisáért felel , mely ez esetben egy `.mdf` fájl
3. Repository 
   - A `Data` és a `Logic` réteg között biztosít kapcsolatot , ebben az esetben a 3 fő modellhez tartozó **CRUD** metódusok szerepelnek itt
4. Logic 
   -  A `Repository` réteget felhasználva megvalósítja a **CRUD** és **NON-CRUD** metódusokat
5. GameHubProjekt
   - Maga a .Net Core Web Applikáció , ez tartalmazza a controllert (hiszen MVC tervezési mintát használunk) , a megjelenítéshez szükséges `HTML` oldalakat és a hozzájuk tartozó stylesheeteket és képeket 
6. Test 
   - `NUnit`-ot és `Moq`-t használva teszteket tartalmaz az összes **CRUD** metódushoz illetve 3  **NON-CRUD** metódushoz mock-olt repository-t használva
   
## Modellek 

Az egyes modellek és adattagjaik , melyeket akár meg is változtathatunk az applikáció futása során:

1. User 
   - **Name** : Felhasználó neve 
   - **Age** : Felhasználó kora
2. Game 
   - **Name** : Játék neve
   - **Genre** : Játék tipusa
   - **GameTime** : A felhasználó által futattott játék használati ideje
   - **Rating** : Játék értékelése
3. Achievement
   - **Name** : Kitüntetés neve
   - **AchiLevel** : Kitüntetés szintje , ez lehet bronz/ezüst/arany , mely később a játékosok pontjainak számításakor 10/20/30 pontot érnek majd

> Természetesen minden osztályhoz tartozik egy ID adattag melyek futási idő alatt jönnek létre 
</br>
> Ezeken felül minden osztályhoz tartozik egy adattag mely a példányt tartalmazó másik pédányra mutat (ha létezik olyan) , illetve a tartalmazó osztályban egy lista(pl. egy játéknak kötelező tartalmaznia egy UserId-t , a játékosnak pedig egy GameLibrary listát) ezután a kapcsolat tranzienseket használva jön létre.
</br>
> Minden esetben szigorúan one-to-many kapcsolat áll fent



 








