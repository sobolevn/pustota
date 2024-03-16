# pustota

[pustota](https://ru.wikipedia.org/wiki/%D0%9F%D1%83%D1%81%D1%82%D0%BE%D1%82%D0%B0) is a minimalistic VSCode theme inspired by old-fashioned hobbies.

[Install it from the official website](https://marketplace.visualstudio.com/items?itemName=sobolevn.pustota) or install it with CLI: `code --install-extension sobolevn.pustota`

Core features:
- Minimalistic
- Borderless
- High contrast for the needed parts
- Small amount of colors
- Only statically known parts are highlighed

Unlike many other themes, this one only highlights:
1. Comments (`#626A73`)
2. Strings (`#C2D94C`)
3. Constants (`#E6B450`)
4. Keywords and operators (`#FF8F40`)
5. Function definitions (`#FFB454`)
6. Type definitions (`#59C2FF`)
7. Everything is just white (`#B3B1AD`)

Basically, this is it.

Pairs greatly with [`FiraCode`](https://github.com/tonsky/FiraCode) font and [`sobole`](https://github.com/sobolevn/sobole-zsh-theme) theme for ZSH.

This theme does not include an icon theme, so you can use any:
- `Ayu` has a great one that I am using
- `Seti` - the default one - is also fine

You can also check my [`.dotfiles`](https://github.com/sobolevn/dotfiles) with the whole setup.

## Showcase

Theme with [my VSCode settings](https://github.com/sobolevn/dotfiles/tree/master/vscode):

![minimal](https://raw.githubusercontent.com/sobolevn/pustota/master/assets/minimal.png)

![main](https://raw.githubusercontent.com/sobolevn/pustota/master/assets/main.png)

Theme with default VSCode settings:

![default](https://raw.githubusercontent.com/sobolevn/pustota/master/assets/default.png)

![default-terminal](https://raw.githubusercontent.com/sobolevn/pustota/master/assets/default-terminal.png)

## Thanks to

- [Ayu Dark](https://github.com/ayu-theme/vscode-ayu) which was the main source of the style and colors (and even some tests)
- [Alabster](https://github.com/tonsky/vscode-theme-alabaster) for the concept of "small visual noise"
