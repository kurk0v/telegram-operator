   M S B A M L   `   `   `  ????  TelegramOperator$    TelegramOperator.Pages.Message   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5   	     N? Title$  Message??5	      .??5      ?  ? ColumnDefinitions 5   
   ?? 5      $??* ?6   6+    ? RowDefinitions 5   
   ?? 5      6   ?? 5      $??* ?6   6*   ?? 5      $	??400 ?6   6,   .+?5   
   ? $??1??6   $??0??6   .+?5      ]? ??.  $
??Left=?6.   $
??1020??6I   $??
10,10,0,10q?6V   .+?5      ?? $	??Top=?6   $??Timeout??6-   $??DemiBold"?6?   $??15(?6U    ?? Left$	 190??6e   
 ?? Top$ 74??6w   $??28??6?   ?? 5      -   5         ??Name$ Slider??5   /   $
??Left=?6    ? Maximum$ 10000Q?6@    ?? IsSnapToTickEnabled .  ?? TickPlacement$ BottomRight=?6k   	 ?? TickFrequency$
	 1000Q?6?   $	??230??6?   $??25??6?   ?? 5         RoundTextBox#??[  6   $??50??6?   $??25??6?   ??6A   ?? *Value+
 ?? ElementName$
 Slider?? ?? UpdateSourceTrigger$ PropertyChanged=?6?   ?? 5      $
??Left=?6   $??image??6.   $??Medium"?6>   $??15(?6S   $??28??6c   $??50??6o   $??10q?6z   $??Normal$?6?   ?? 5       -   5         ??Name$ 
photocheck??5         ToggleButtonStyle#??[ 6/   $
??Left=?6Z   ?? 5!      -   5         ??Name$ username??5!      $
??Left=?6,   #??[  6B   $	??120??6h   $??10q?6t   ?? 5"      -   5        $ message??5"      $
??Left=?6+   #??[  6A   $	??317??6g   ?? 5#      -   5         ??Name$
 Home??5#        MenuRoundButton#??[ 6(   .??5$      "  FontAwesome.WPF.ImageAwesome     Icon$ 	Paperclip=?6&     MenuButtonIcon#??[ 68   6b   5%      5&      5*      ? 5+   
   $??2??6   $??0??6   .+?5,      ?? -   5         ??Name$ 
imgPicture??5,      $
??Left=?6(   $	??348??6C   $??
588,19,0,0q?6P   $	??Top=?6d   $	??400??6|   5.      ?? 50   
   -   5        $	 SMS??50        PouringButton#??[ 6   $??Отправить??6E   $	??Top=?6Z   6r   52      53      