# TODO-lista sovellus

TODO-sovellus tehdään 2-3 hengen ryhmissä. Tehtävä tulee GitHub Classroomin kautta suoraan ryhmärepositoryksi.

## Ohjelmistokehityksen simulointia
Asiakas haluaa yksinkertaisen konsolipohjaisen todo-applikaation (asiakasta simuloi opettaja). Asiakkaan tarkoituksena olisi mahdollisesti jatkokehittää ohjelmaa esim. lisäämällä erilaisen käyttöliittymän, mutta hän tietää vain, että haluaa yksinkertaisen TODO-applikaation omaan käyttöön. Voi olla, että ohjelmaa haluaa käyttää useampikin ihminen jatkossa.

 ### 1 vaiheen tehtävät:

Hyväksykää GitHub classroomin tehtävä. Ensimmäisestä hyväksyjästä tulee ryhmän "kapteeni". Muut voivat valita ryhmän ja liittyä siihen. Githubin kehitys/release branchina toimii main-branch. Jakakaa tehtävät niin, että jokainen ryhmän jäsen luo oman branchin, johon lähtee toiminnallisuutta tekemään. **Lisätkää githubin repositoryyn myös .gitignore tiedosto, joka sopii Visual Studiolle ja C#-kielelle. Päivittäkää GitHubia mahdollisimman usein.**
Alla esimerkki, jossa jokainen feature kuvastaa ryhmän henkilön tekemää toiminnallisuutta:
<img style="float: left;" src="https://user-images.githubusercontent.com/33627661/158330612-1938f11b-7d76-4bf7-a01b-c69956e87e89.PNG">

Kuvan lähde: https://www.gitkraken.com/learn/git/best-practices/git-branch-strategy

### Esimerkki kahden opiskelijan työn aloituksesta:

Ryhmän jäsen 1

1. Toinen ryhmäläinen tekee .gitignoren etsii netistä oikeat sisällöt (visual studio c#)
2. Laita .gitignore tulee ohjelman pääkansioon (sama missä .git kansio on). Tallenna tiedosto Save as ja all files.
3. git add . git commit -m" gitignore" git push


Ryhmän jäsen 2

1. Tee uusi console application git kansioon eli siihen kansioon, jonka kloonasit githubista.
2. git add . paina enter
3. git commit -m "added base code" paina enter
4. git push paina enter
5. Tässä vaiheessa git todennäköisesti sanoo jotain seuraavanlaista: your branch is 1 commit behind origin/main
6. Hae muutokset git pull komennolla
7. Puske uudet muutokset

### Projektin workflow

Tarkoituksena on käyttää brancheja hyödyntävää workflow:ta https://www.atlassian.com/git/tutorials/comparing-workflows/feature-branch-workflow.

Tarkoituksena on, että uudet ominaisuudet tehdään projektin main branchin pohjalta. Jokainen uusi ominaisuus yhdistetään mainiin, jonka pohjalta luodaan seuraavat kehitysbranchit. Luo uusi branchi mainin pohjalta seuraavasti: 

*Huom!* Alla oleva komento olettaa, että koodin uusin ja ylläpidetty versio on githubin main branchissa.
```
git checkout main
git fetch origin 
git reset --hard origin/main
```

Luo uusi branchi mainin pohjalta:

```
git checkout -b new-feature
```

Kun oma toiminnallisuus on valmis eli olet saanut luotua toimivan metodin, niin puske muutokset remote githubiin. Gitbash antaa virheilmoituksen ja jatkohjeet, jonka avulla saat luotua branchistasi remote version. Kun olet puskenut muutokset aloita oman branchisi yhdistäminen main branchiin pull-requestin avulla.

https://docs.github.com/en/pull-requests/collaborating-with-pull-requests/incorporating-changes-from-a-pull-request/merging-a-pull-request

Jos mergen yhteydessä tulee konflikteja, niin ne pitää selvittää joko GitHubissa:
https://docs.github.com/en/pull-requests/collaborating-with-pull-requests/addressing-merge-conflicts/resolving-a-merge-conflict-on-github

tai vaihtoehtoisesti Visual Studion avulla.
https://docs.microsoft.com/en-us/visualstudio/version-control/git-resolve-conflicts?view=vs-2022


Ohjeita vim-editorin käyttöön, jos sellainen aukeaa mergen yhteydessä: https://www.cyberciti.biz/faq/linux-unix-vim-save-and-quit-command/

**Huom! Kun toiminnallisuus on valmis, yhdistäkää haaranne (branch) main haaraan ja poistakaa feature branch.**

Tehkää ohjelmaan tarvittavat luokat sekä seuraavat toiminnallisuudet.
   + Luo tehtävä
   + Lisää tehtäviä listaan
   + Poista tehtäviä listasta
   + Merkitse tehtävä tehdyksi

#### Github harjoituksia
 Kun ensimmäisen vaiheen toiminnallisuudet ovat kunnossa, jokainen muokkaa "vahingossa" AddItemToList-metodin toimintaa. Selvittäkää mahdolliset konfliktit.
 
     
 ###  2 vaiheen tehtävät:
   + Luo tekstipohjainen käyttöliittymä, joka näyttää todo listan sisällön. Ideoita ja visuaalisuutta voi hakea esim. http://programmingisfun.com/command-line-ascii-design/

#### Github harjoituksia
  + Jokainen opiskelija lisää main haaraan jotain turhaa eli jokainen voi lisätä jotain turhaa koodia main haaraan. Palauttakaa main-haaran tila viimeistä puskua edeltävään tilaan, jossa turhaa/virheellistä toiminnallisuutta ei vielä ole.
  + Palauttakaa main-haaran tila aikaisempaan versioon, jossa ei ole mitään turhia kommentteja/koodia.

 ###  3 vaiheen tehtävät:
 Todo-tehtävät tulisi voida tallentaa listaan. Selvittäkää ryhmänne sisällä olisiko teillä jo valmista luokkaa/luokkia, joita voisitte hyödyntää ja lisätkää toiminnallisuus ohjelmaanne.
  + Luo kansio nimeltä todolist. Jos kansio on olemassa, ei uutta kansiota tarvitse luoda, mutta ilmoitetaan, että kansio on olemassa.
  + Tallenna tehtävät tiedostoon 
  + Poista tehtävä tiedostosta
 
 ### 4 vaiheen tehtävä:
 Kun projekti on valmis, tehkää projektista uusi luokkakaavio esim. https://drawio-app.com/ työkalun avulla.
 
 ### Bonus
   + Tallenna tehtävät tiedostoon JSON-formaatissa https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-how-to?pivots=dotnet-5-0
   + Muuta ohjelmaa niin, että se toimii samalla tavalla kuin aikasemminkin
   
  ### Luokkakaavio
  ![TodoClassDiagram](https://user-images.githubusercontent.com/33627661/157511965-1f913690-253b-4a55-a9fd-1f8c6d28500f.PNG)
