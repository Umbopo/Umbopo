﻿using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;

/* This class enables two-way data binding as well as sorting. 
 * 
 * The class derives from ObservableCollection<T> and adds an explicit 
 * implementation of IListSource. 
 * 
 * The GetList() method of IListSource is implemented to return an IBindingList 
 * implementation that stays in sync with the ObservableCollection. 
 * 
 * The IBindingList implementation generated by ToBindingList supports sorting. 
 * 
 * The ToBindingList extension method is defined in the EntityFramework assembly.
 */

namespace Bode
{
    public class ObservableListSource<T> : ObservableCollection<T>, IListSource
                where T : class
    {
        private IBindingList _bindingList;

        bool IListSource.ContainsListCollection { get { return false; } }

        IList IListSource.GetList()
        {
            return _bindingList ??= this.ToBindingList();
        }
    }
}