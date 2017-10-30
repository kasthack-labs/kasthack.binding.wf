# kasthack.binding.wf

[![Nuget](https://img.shields.io/nuget/v/kasthack.binding.wf.svg)](https://www.nuget.org/packages/kasthack.binding.wf/)
[![NuGet](https://img.shields.io/nuget/dt/kasthack.binding.wf.svg)](https://www.nuget.org/packages/kasthack.binding.wf/)
[![Build status](https://img.shields.io/appveyor/ci/kasthack/kasthack-binding-wf.svg)](https://ci.appveyor.com/project/kasthack/kasthack-binding-wf)
[![License](https://img.shields.io/badge/license-LGPL-green.svg)](https://github.com/kasthack/kasthack.binding.wf/blob/master/LICENSE.txt)
[![Gitter](https://img.shields.io/gitter/room/nwjs/nw.js.svg)](https://gitter.im/kasthack_binding_wf)

## What

Windows.Forms data binding lambda helper. Gets rid of that literal / nameof bullshit in your code.

## Installation

`Install-Package kasthack.binding.wf`

## Usage

`control.Bind(a=>a.ControlProperty, model, a=>a.ModelProperty.ModelSubProperty)`

## Bugs / issues

Fork off / pull