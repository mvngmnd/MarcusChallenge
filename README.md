# Marcus Challenge

## Reasoning behind certain sections:

### Clientside
Material UI was used for nice and quick form entering section, without having to introduce heavy styling sheets. Other solutions could have included Bootstrap, Tailwind-CSS or Materialize etc...
Opted not for these as prefer the inline styling approach or use of React style sheeting as opposed to class based CSS. Especially for a small project like this. Basically didnt want to have to write the entire world just for this small section.

### Serverside
For the code challenge, I opted to try use recursion as I noticed some patterns with how sequences of numbers work, and that they should be easily broken down into basic numbers plus their denomination (IE: Three hundred million and ten is just f(300) + "million" + f(remainder) ).

I also opted to make the functions sit inside of a helper class, as I believe they lend them selves to more of a utility function, as opposed to be injected through as a service.

## Testing
I only managed to find enough time to complete the challenge + test the serverside. If I had given more time, I would have used Jest + React Testing Library. The tests would have been fairly novel for this, such as asserting state changes on input, and that the error and validation fields are set properly on user input.

IE: Assert box is orange on wrong input.
