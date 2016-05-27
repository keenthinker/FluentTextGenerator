# FluentTextGenerator

Configurable fluent API for random text generation.

-----------------------------------------------------
This library can be used to create random strings, for example for automated key generation.

The simplest way to generate a random string is to use the default library configuration:

<code>
  Console.WriteLine(new FluentTextGenerator().Configure().Generate()); // BuJZKhWk3BQsA{O1ho-...
</code>

The default configuration generates strings using:
- random minimal length (a value between 1 and 250)
- random maximal length (a value between 1 and 250; >= the minimal length)
- an alphabet consisting of
  - small characters a-z
  - capital characters A-Z
  - numbers 0-9
  - special symbols .,+-*/!?;:{}()[]%$&~#@|><

