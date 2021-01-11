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



 








