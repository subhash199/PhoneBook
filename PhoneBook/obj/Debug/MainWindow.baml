   M S B A M L   `   `   `  ????D  @PhoneBook, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:PhoneBook	PhoneBook  5   	       PhoneBook.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:PhoneBook     5   	     ? Title$  
MainWindow??5   	   $	??500??6   $	??375??6)   .??5	      ? .+?5
   
   ??  ?? Orientation$ Vertical=?6   .+?5      ?? $ 
Horizontal=?6   $??Center=?62   .+?5      ?? $??Phone Book App??6   $??0,0,0,0q?61   $??16(?6C   5      ]? 5      .+?5      ?? $??Contacts??6   $??16(?6+   $
??Left=?69   6W   ?? 5      -   5        $?? + Add Contact??5      $??16(?62   
????? ?$??0,0,0,0q?6q   $??right=?6?   5      ]? 5      $??0,10,0,0q?6   .+?5      ?? $??Search??6   $??16(?6)   69   ?? 5      -   5         ??Name$ 
Search_Box??5   &   $??23??6    ?? TextWrapping$
 Wrap=?6_   $?? ??6s   5      ?? 5      -   5         ??Name$ Contact_Box??5      $
??auto??6,   $??16(?6:   
???   ? ?? View 5      ?? 5      .P?5      ?? $??
First Name??6)    ?? Width$ 90??6=   -   5        	fname?? ?? DisplayMemberBinding 5   W   ?? *	firstName+?? 5      $??	Last Name??6)   $ 90??6<   -   5        	lname?? 5   V   ?? *
lastName+?? 5      $??Number??6)   $ 90??69   -   5        
number?? 5   T   ?? *number+?? 5      $
??Edit??6)   $ 90??67    ?? CellTemplate 5      ?? 5   "   .R?5   &   ?? -   5        $
??Edit??5   J   $??90??6Y   ??6-   ?? 6d   5    #   5"      5#      5&      5(      5*      5+      