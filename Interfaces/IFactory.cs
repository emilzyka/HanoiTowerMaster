namespace Brickleken
{
    interface IFactory<in T1, out T2> //bivariant
    {
        public T2 create(T1 command);
    }
}


//Kovariant eftersom substitutions reglerna för, NormalPush : IPushBehavior, är bevarad över en mappning till en generisk typ.  
//"NormalPush : IPushbehavior, beter sig som: I<NormalPush> : I<IPushBehavior>"

/*
IFactory<NormalPush> f1 = null!;'

NormalPush derived1 = f1.create(" "); //tillåtet 
IPushBehavior base1 = f1.create(" "); //tillåtet

IFactory<IPushBehavior> f2 = null!;
IPushBehavior base2 = f2.create(" "); //tillåtet  
NormalPush derived2 = f2.create(" "); //förbjudet 

*/


