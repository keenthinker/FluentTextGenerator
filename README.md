# FluentTextGenerator

Configurable fluent API for random text generation.

-----------------------------------------------------
This library can be used to create random strings, for example for automated key generation.

The simplest way to generate a random string is to use the default library configuration:

	Console.WriteLine(new FluentTextGenerator().Configure().Generate()); // BuJZKhWk3BQsA{O1ho-...

The default configuration generates strings using:
- random minimal length (a value between 1 and 250)
- random maximal length (a value between 1 and 250; >= the minimal length)
- an alphabet consisting of
  - small characters a-z
  - capital characters A-Z
  - numbers 0-9
  - special symbols .,+-*/!?;:{}()[]%$&~#@|><

Every option can be explicitely set using the fluent API:
- *MinLength(int min)*
	- default is 0, meaning random between 1 and 250
- *MaxLength(int max)*
	- default is 0, meaning random between 1 and 250, but >= MinLength
- *IncludeCapitalCharacters(bool yes)* 
	- default is true
- *IncludeSmallCharacters(bool yes)*
	- default is true
- *IncludeNumbers(bool yes)*
	- default is true
- *IncludeSpecialCharacters(bool yes)*
	- default is true

This call:

	Console.WriteLine(new FluentTextGenerator()
				.Configure()
				.MinLength()
				.MaxLength()
				.IncludeCapitalCharacters()
				.IncludeSmallCharacters()
				.IncludeNumbers()
				.IncludeSpecialCharacters()
				.Generate());

is the same as the first example:

	Console.WriteLine(new FluentTextGenerator().Configure().Generate());

Using the fluent API the configuration could be set from some custom settings:

	Console.WriteLine(new FluentTextGenerator()
				.Configure()
				.MinLength(min)
				.MaxLength(max)
				.IncludeCapitalCharacters(includeCapitalCharacters)
				.IncludeSmallCharacters(includeSmallCharacters)
				.IncludeNumbers(includeNumbers)
				.IncludeSpecialCharacters(includeSpecialCharacters)
				.Generate());

The configuration options can also be used individually or in a combination:

	Console.WriteLine(new FluentTextGenerator()
						.Configure()
						.MinLength(5)
						.MaxLength(10)
						.IncludeSpecialCharacters(false)
						.Generate()); // jYsF3tv

