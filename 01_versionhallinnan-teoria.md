# Git ja github

Git ja github ovat tulleet jo peruskäytöltään tutuksi, mutta tässä vielä kertauksen vuoksi muutamia juttuja.

### Tuttuja komentoja

+ git init https://github.com/git-guides/git-init
+ git clone <https://name-of-the-repository-link> https://github.com/git-guides/git-clone
+ git status https://github.com/git-guides/git-status
+ git add https://github.com/git-guides/git-add
+ git commit -m "added files" https://github.com/git-guides/git-commit
+ git pull https://github.com/git-guides/git-pull
+ git push https://github.com/git-guides/git-push
+ git remote https://github.com/git-guides/git-remote
+ git merge conflicts https://www.atlassian.com/git/tutorials/using-branches/merge-conflicts

## Git ja GitHub workflow

![gitglow](https://user-images.githubusercontent.com/33627661/158259459-e22224c1-d935-4226-ac72-b8646ca13fe1.PNG)

## Uusia komentoja ja konsepteja

+ git branch https://git-scm.com/book/en/v2/Git-Branching-Basic-Branching-and-Merging+ 
  + Creating a branch in GitHub https://docs.github.com/en/desktop/contributing-and-collaborating-using-github-desktop/making-changes-in-a-branch/managing-branches
  + Change branch in git: git checkout mybranch
  + Checkout remote main as new branch: git checkout -b my-feature
  + Change back to main: git checkout main 
   + git checkout commit_sha
  + git pull requests https://docs.github.com/en/pull-requests/collaborating-with-pull-requests/proposing-changes-to-your-work-with-pull-requests/about-pull-requests
+ git log https://git-scm.com/book/en/v2/Git-Basics-Viewing-the-Commit-History
  + git log --graph --all --decorate  
+ git reset 
     +   git reset --soft HEAD~1 
     +   git reset --hard HEAD~1 
     +   git reset --hard 0ad5a7a6 
     +   git reset --hard commit_sha 
     +   To rollback 10 commits back: git reset --hard HEAD~10
+ git rebase https://docs.github.com/en/get-started/using-git/about-git-rebase
+ .gitignore https://www.atlassian.com/git/tutorials/saving-changes/gitignore, https://www.freecodecamp.org/news/gitignore-what-is-it-and-how-to-add-to-repo/
  + Jos lisäätte .gitignoren sen jälkeen ku olette lisänneet Visual Studion tietoja, niin: First of all, commit all pending changes.
  + git rm -r --cached .
  + git add .
  + git commit -m ".gitignore is now working"   
+ esimerkki .gitignore https://github.com/github/gitignore/blob/main/VisualStudio.gitignore
 
