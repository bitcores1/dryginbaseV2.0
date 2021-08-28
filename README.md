# dryginbase for user @dryginbase @bitcores
[webiste](http://dryginbase.ml) and
[@dryginbase](https://github.com/dryginbase)

## about

DCL (reference) is written in c# and System.Xml of microsoft .NET because DCL is code rewritten from dryginbase so there are a lot of bugs and missing things so DCL and Dryginbase will patch the bug and will release the latest version.


### use

Step 1, you go to bin/debug, the second is that you select all files containing the extension *.dll but then you choose DCL.dll and system.dll and some other .NET files (from microsoft) will help DCL .dll works and you can paste the code below

normal
```c#
static void main(string[]args)
{
DCL.Xcase.from = "your path";
DCL.Xcase.index();
}

```
for drag
```c#
static void main(string[]args)
{
  if (args.lenght > 0) {
    System.Console.Title = args[0];
    DCL.Xcase.from = args[0];
    DCL.Xcase.index();
  }
  else {
    //code here
  }
}
```



